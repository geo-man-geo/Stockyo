using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.FinhubContracts;
using StocksApp.Models;
using StocksApp.Models.OptionsPatterns;
using System.Diagnostics;
using System.Xml.Linq;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinhubServices _finhubService;
        private readonly IOptions<TradingOptions> _tradingOptions;
        public HomeController(IFinhubServices finhubService, IOptions<TradingOptions> tradingOptions)
        {
            _finhubService= finhubService;  
            _tradingOptions= tradingOptions;
        }
        [Route("/{Name}")]    
        public async Task<IActionResult> Index(string name)
        {

            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "AMZN";
            }

            Dictionary<string,object>? response =  await _finhubService.GetStockPriceQuote(name);
            StockModel stock = new StockModel()
            {
                StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
                CurrentPrice = Convert.ToDouble(response["c"].ToString()),
                HighPrice = Convert.ToDouble(response["h"].ToString()),
                LowPrice = Convert.ToDouble(response["l"].ToString()),
                OpenPrice = Convert.ToDouble(response["o"].ToString())
            };
            return View(stock);
        }

        [Route("Trade/Index/{Name}")]
        public async Task<ActionResult> GetStockDetails(string Name)
        {
            Dictionary<string, object>? response = await _finhubService.GetCompanyProfile(Name);
            Dictionary<string, object>? price_response = await _finhubService.GetStockPriceQuote(Name);

            StockTrade _stocktrade = new StockTrade()
            {
                StockName = response["name"].ToString(),
                StockSymbol = _tradingOptions.Value.DefaultStockSymbol              
            };
            StockModel _stockModel = new StockModel()
            {
                CurrentPrice = Convert.ToDouble(price_response["c"].ToString()),
            };

            StockMaster stockMaster = new StockMaster()
            {
                stockModel = _stockModel,
                stockTrade = _stocktrade
            };
            return View(stockMaster);    
        }
    }
}
