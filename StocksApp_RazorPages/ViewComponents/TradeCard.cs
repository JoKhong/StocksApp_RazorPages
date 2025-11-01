using Microsoft.AspNetCore.Mvc;
using SharedModels;

namespace StocksApp_RazorPages.ViewComponents
{
    public class TradeCard : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(StockTrade trade)
        {
            return View(trade);
        }
    }
}
