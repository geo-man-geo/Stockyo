using System.ComponentModel.DataAnnotations;

namespace StocksApp.Models.Entities
{
    public class BuyOrder
    {
        public Guid BuyOrderID { get; set; }

        [Required(ErrorMessage = "StockSymbol is mandatory")]
        public string? StockSymbol { get; set; }

        [Required(ErrorMessage = "StockName is mandatory")]
        public string? StockName { get; set; }
        public DateTime? DateAndTimeOfOrder { get; set; }
        public uint? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
