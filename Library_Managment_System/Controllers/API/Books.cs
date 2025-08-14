using Library_Managment_System.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_System.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Books : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public Books(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddBook(Library_Managment_System.Models.Books Books)
        {
            try
            {
                var Data = await _dbcontext.Books.Where(o => o.title == Books.title).FirstOrDefaultAsync();
                if (Data == null)
                {
                    _dbcontext.Books.Add(Books);
                    await _dbcontext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Book Add Successfully...!" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Book Already Exist" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("BookList")]
        public async Task<IActionResult> GetBook()
        {
            try
            {
                var Data = await _dbcontext.Books.ToListAsync();
                return Ok(new { Status = "Ok", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("BooksCategories")]
        public async Task<IActionResult> BooksCategories()
        {
            try
            {
                var Data = await (from Books in _dbcontext.Books
                                  join Categories in _dbcontext.Categories
                                  on Books.category_id equals Categories.category_id
                                  select new
                                  {
                                      Books.title,
                                      Books.publisher,
                                      Books.author,
                                      Books.available_copies,
                                      Books.book_id,
                                      Books.isbn,
                                      Categories.category_name,
                                  }).ToListAsync();
                return Ok(new { Status = "Ok", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("Book/{book_id?}")]
        public async Task<IActionResult> Book(int book_id)
        {
            try
            {
                var Data = await (from Books in _dbcontext.Books
                                  join Categories in _dbcontext.Categories
                                  on Books.category_id equals Categories.category_id
                                  where Books.book_id == book_id
                                  select new
                                  {
                                      Books.title,
                                      Books.publisher,
                                      Books.author,
                                      Books.available_copies,
                                      Books.book_id,
                                      Books.category_id,
                                      Books.isbn,
                                      Categories.category_name,
                                  }).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Book Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteBook/{book_id?}")]
        public async Task<IActionResult> DeleteBook(int book_id)
        {
            try
            {
               var Data = await _dbcontext.Books.Where(o => o.book_id == book_id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    _dbcontext.Books.Remove(Data);
                    await _dbcontext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Book Delete Successfully...!" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Book Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpPost]
        [Route("UpdateBook")]

        public async Task<IActionResult> UpdateBook(Library_Managment_System.Models.Books Books)
        {
            try
            {
                _dbcontext.Books.Update(Books);
                await _dbcontext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Book Update Successfully...!" });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }
    }
}
