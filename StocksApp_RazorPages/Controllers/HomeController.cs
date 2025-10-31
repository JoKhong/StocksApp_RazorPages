using Microsoft.AspNetCore.Mvc;
using FinnhubContracts;
using SharedModels;

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
            string stockName = "MSFT";

            Dictionary<string, object>? responseDictionary = await _finnhubService.GetStockPriceQuote(stockName);

            Stock stock = new Stock()
            {
                StockSymbol = stockName,
                CurrentPrice = Convert.ToDouble(responseDictionary["c"].ToString()),
                HighestPrice = Convert.ToDouble(responseDictionary["h"].ToString()),
                LowestPrie = Convert.ToDouble(responseDictionary["l"].ToString()),
                OpenPrice = Convert.ToDouble(responseDictionary["o"].ToString())
            };

            return View(stock);
        }
    }
}
