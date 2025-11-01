using FinnhubContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedModels;

namespace StocksApp_RazorPages.Controllers
{
    public class TradeController : Controller
    {
        private readonly IFinnhubService _finnhubService;
        private readonly IOptions<TradingOptions> _tradingOptions;

        public TradeController(IFinnhubService finnhub, IOptions<TradingOptions> tradingOptions)
        {
            _finnhubService = finnhub;
            _tradingOptions = tradingOptions;
        }

        [Route("trade")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }

            Dictionary<string, object>? stockQuote = await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);
            Dictionary<string, object>? companyProfile = await _finnhubService.GetCompanyProfile(_tradingOptions.Value.DefaultStockSymbol);

            StockTrade stockTrade = new SharedModels.StockTrade
            {
                StockSymbol = Convert.ToString(companyProfile["ticker"].ToString()),
                StockName = Convert.ToString(companyProfile["name"].ToString()),
                Price = Convert.ToDouble(stockQuote["c"].ToString()),
                Quantity = Convert.ToDouble(stockQuote["shareOutstanding"].ToString()),
            };

            return View(stockTrade);
        }
    }
}
