namespace StocksApp.FinhubContracts
{
    public interface IFinhubServices
    {
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
        Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);
    }
}
