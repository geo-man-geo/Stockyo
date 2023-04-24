namespace StocksApp.Models.Entities
{
    public class SellOrder
    {
        public Guid BuyOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime? DateAndTimeOfOrder { get; set; }
        public uint? Quantity { get; set; }
        public double? Price { get; set; }

    }
}
