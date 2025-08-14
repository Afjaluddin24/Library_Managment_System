using Library_Managment_System.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_System.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontex;

        public Categories(ApplicationDbContext dbcontex)
        {
            _dbcontex = dbcontex;
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(Library_Managment_System.Models.Categories categories)
        {
            try
            {
                var Data = await _dbcontex.Categories.Where(o => o.category_name == categories.category_name).FirstOrDefaultAsync();

                if (Data == null)
                {
                    _dbcontex.Categories.Add(categories);
                    await _dbcontex.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Category add Successfully" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Category Already Exist" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            try
            {
                var Data = await _dbcontex.Categories.ToListAsync();
                return Ok(new { Status = "Ok", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("Category/{category_id?}")]

        public async Task<IActionResult> ListCategory(int category_id)
        {
            try
            {
                var Data = await _dbcontex.Categories.Where(o => o.category_id == category_id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Data Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpDelete]
        [Route("CategoryRemove/{category_id?}")]

        public async Task<IActionResult> RemoveCategory(int category_id)
        {
            try
            {
                var Data = await _dbcontex.Categories.Where(o => o.category_id == category_id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    _dbcontex.Categories.Remove(Data);
                    await _dbcontex.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Delete Successfullly" });

                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Data Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Library_Managment_System.Models.Categories categories)
        {
            try
            {
                //var Data = await _dbcontex.Categories.Where(o => o.category_id == categories.category_id).FirstOrDefaultAsync();
                //if(Data != null)
                //{
                    _dbcontex.Categories.Update(categories);
                    await _dbcontex.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Category Update Successfully" });
                //}
                //else
                //{
                //    return Ok(new { Status = "Fail", Result = "" });
                //}

            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }
    }
}
