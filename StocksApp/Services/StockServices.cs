using StocksApp.FinhubContracts.DTO;
using StocksApp.FinhubContracts;
using StocksApp.Models.Entities;
using System.Runtime.CompilerServices;
using StocksApp.Services.ValidationHelpers;

namespace StocksApp.Services
{
    public class StockServices : IStockServices
    {
        private readonly List<BuyOrder>? _buyOrders;
        public StockServices()
        {
            _buyOrders = new List<BuyOrder>();

        }
        public BuyOrderResponse? CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            if(buyOrderRequest == null)
                throw new ArgumentNullException(nameof(buyOrderRequest));

            ModelValidatonHelper.ModelValidation(buyOrderRequest);
            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
            buyOrder.BuyOrderID = Guid.NewGuid();
            _buyOrders?.Add(buyOrder);
            BuyOrderResponse buyOrderResponse = buyOrder.ToBuyOrderResponse();
            return buyOrderResponse;
        }

        public List<BuyOrderResponse> GetBuyOrders()
        {
            throw new NotImplementedException();
        }
    }
}
