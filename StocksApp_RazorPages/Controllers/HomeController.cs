using Microsoft.AspNetCore.Mvc;

namespace StocksApp_RazorPages.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
