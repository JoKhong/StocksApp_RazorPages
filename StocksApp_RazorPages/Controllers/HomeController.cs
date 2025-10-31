using Microsoft.AspNetCore.Mvc;
using FinnhubContracts;

namespace StocksApp_RazorPages.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnhubService _finnhubService;

        public HomeController(IFinnhubService finnhub)
        {
            _finnhubService = finnhub;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string, object>? responseDictionary = await _finnhubService.GetStockPriceQuote("MSFT");

            return View(responseDictionary);
        }
    }
}
