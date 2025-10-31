using Microsoft.AspNetCore.Mvc;
using SharedModels;

namespace StocksApp_RazorPages.ViewComponents
{
    public class StockPriceCard : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Stock stock)
        { 
            return View(stock);
        }
    }
}
