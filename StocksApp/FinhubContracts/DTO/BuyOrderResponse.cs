using System.Runtime.CompilerServices;
using StocksApp.Models.Entities;

namespace StocksApp.FinhubContracts.DTO
{
    public class BuyOrderResponse
    {
        public Guid BuyOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime? DateAndTimeOfOrder { get; set; }
        public uint? Quantity { get; set; }
        public double? Price { get; set; }
        public double? TradeAmount
        {
            get
            {
                return TradeAmount;
            }
            set
            {
                double? TradeAmount = Quantity * Price;
            }
        }
    }
    
    public static class BuyOrderExtension
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse
            {
                BuyOrderID = buyOrder.BuyOrderID,
                StockSymbol = buyOrder.StockSymbol,
                StockName = buyOrder.StockName,
                Price = buyOrder.Price,
                Quantity = buyOrder.Quantity,
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder
            };
        }
    }
}
