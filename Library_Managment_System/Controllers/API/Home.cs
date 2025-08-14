using Library_Managment_System.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library_Managment_System.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public Home(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("HomeDetals")]
        public async Task<IActionResult> HomeDetals()
        {
            try
            {
                var categoriesCount = _dbcontext.Categories.Count();
                var booksCount = _dbcontext.Books.Count();
                var membersCount = _dbcontext.Members.Count();
                var transactionsCount = _dbcontext.Transactions.Count();

                return Ok(new{Status = "Ok", Result = new
                {
                    Categories =  categoriesCount,
                    Books = booksCount,
                    Members = membersCount,
                    Transactions = transactionsCount
                }
                    
                    });
            }
            catch (Exception ex)
            {
                return Ok(new{Status = "Fail",Result = ex.Message});
            }
        }

    }
}
