using Microsoft.AspNetCore.Mvc;

namespace Library_Managment_System.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Categories")]
        public IActionResult Categories()
        {
            return View();
        }
        [HttpGet]
        [Route("Books")]
        public IActionResult Books()
        {
            return View();
        }
        [HttpGet]
        [Route("Member")]
        public IActionResult Member()
        {
            return View();
        }

        [HttpGet]
        [Route("Staff")]
        public IActionResult Staff()
        {
            return View();
        }

        [HttpGet]
        [Route("Transaction")]
        public IActionResult Transaction()
        {
            return View();
        }
        [HttpGet]
        [Route("Modify/{Book?}")]
        public IActionResult TransactionUpdate(int Book)
        {
            ViewBag.BookId = Book;
            return View();
        }
    }
}
