using Library_Managment_System.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Managment_System.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Transactions : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public Transactions(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        [HttpPost]
        [Route("AddTransactions")]
        public async Task<IActionResult> AddTransactions(Library_Managment_System.Models.Transactions transactions)
        {
            try
            {
                _dbcontext.Transactions.Add(transactions);
                await _dbcontext.SaveChangesAsync();
                return Ok(new {Status = "Ok", Result = "Book transactions successfully."});
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }

        }

        [HttpGet]
        [Route("TransactionsList")]
        public async Task<IActionResult> TransactionsList()
        {
            try
            {
                var Data = await (from Books in _dbcontext.Books 
                                  join Transactions in _dbcontext.Transactions on Books.book_id equals Transactions.book_id
                                  join Member in _dbcontext.Members on Transactions.member_id equals Member.member_id select new
                                  {
                                      Books.title,
                                      Transactions.issue_date,
                                      Transactions.due_date,
                                      Transactions.return_date,
                                      Transactions.status,
                                      Transactions.member_id,
                                      Transactions.book_id,
                                      Transactions.transaction_id,
                                      Member.name,
                                      Member.email,
                                      Member.phone
                                  }).ToListAsync();
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
        [HttpGet]
        [Route("TransactionsList/{transaction_id?}")]
        public async Task<IActionResult> TransactionsList(int transaction_id)
        {
            try
            {
                var data = await (from book in _dbcontext.Books
                                  join transaction in _dbcontext.Transactions on book.book_id equals transaction.book_id
                                  join member in _dbcontext.Members on transaction.member_id equals member.member_id
                                  where transaction.transaction_id == transaction_id
                                  select new
                                  {
                                      book.title,
                                      transaction.issue_date,
                                      transaction.due_date,
                                      transaction.return_date,
                                      transaction.status,
                                      transaction.member_id,
                                      transaction.book_id,
                                      transaction.transaction_id,
                                      member.name,
                                      member.email,
                                      member.phone
                                  }).ToListAsync();

                if (data != null)
                {
                    return Ok(new { Status = "Ok", Result = data });
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
        [HttpGet]
        [Route("Transactions/{transaction_id?}")]
        public async Task<IActionResult> Transaction(int transaction_id)
        {
            try
            {
                var Data = await _dbcontext.Transactions.Where(o => o.transaction_id == transaction_id).FirstOrDefaultAsync();
                if(Data != null)
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

        [HttpPost]
        [Route("UpdateTransactions")]
        public async Task<IActionResult> UpdateTransactions(Library_Managment_System.Models.Transactions transactions)
        {
            try
            {
                var existingTransaction = await _dbcontext.Transactions.FindAsync(transactions.transaction_id);

                if (existingTransaction == null)
                {
                    return NotFound(new { Status = "Fail", Result = "Transaction not found." });
                }

                // ✅ Correct property names (matching your model)
                existingTransaction.status = transactions.status;
                existingTransaction.return_date = transactions.return_date;

                // Optional: force EF to track changes
                _dbcontext.Entry(existingTransaction).State = EntityState.Modified;

                await _dbcontext.SaveChangesAsync();

                return Ok(new { Status = "Ok", Result = "Book returned successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = "Fail", Result = ex.Message });
            }
        }


    }
}
