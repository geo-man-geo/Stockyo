using StocksApp.FinhubContracts.DTO;

namespace StocksApp.FinhubContracts
{
    public interface IStockServices
    {
        BuyOrderResponse? CreateBuyOrder(BuyOrderRequest? buyOrderRequest);

        List<BuyOrderResponse> GetBuyOrders();

    }
}
