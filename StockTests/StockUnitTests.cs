using StocksApp.Services;
using StocksApp.FinhubContracts;
using StocksApp.FinhubContracts.DTO;
namespace StockTests
{
    public class StockUnitTests
    {
        private readonly IStockServices _stockServices;
        public StockUnitTests()
        {
            _stockServices = new StockServices();
        }
        #region
        [Fact]
        public void BuyStock_NullArgument()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = null;

            //Assert
             Assert.Throws<ArgumentNullException>(() => 
             {
                //Act
                 _stockServices.CreateBuyOrder(buyOrderRequest);
             });

        }
        [Fact]
        public   void BuyStock_BuyOrderQuantitytIsZero()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest();
            buyOrderRequest.Quantity = 0;
            //Assert
            Assert.Throws<ArgumentException>(() => 
            {
                //Act
                _stockServices.CreateBuyOrder(buyOrderRequest);
            });

        }

        [Fact]
        public void BuyStock_BuyOrderQuantitygreaterThan10000()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest();
            buyOrderRequest.Quantity = 10001;
            //Assert
             Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockServices.CreateBuyOrder(buyOrderRequest);
            });

        }

        [Fact]
        public void BuyStock_BuyOrderPricetIsZero()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest();
            buyOrderRequest.Price = 0;
            //Assert
             Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockServices.CreateBuyOrder(buyOrderRequest);
            });

        }

        [Fact]
        public void BuyStock_BuyOrderPricegreaterThan10000()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest();
            buyOrderRequest.Price = 10001;
            //Assert
             Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockServices.CreateBuyOrder(buyOrderRequest);
            });

        }
        [Fact]
        public void BuyStock_DateCheck()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest();
            buyOrderRequest.DateAndTimeOfOrder = DateTime.Parse("2009-09-09");
            //Assert
             Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockServices.CreateBuyOrder(buyOrderRequest);
            });

        }


        [Fact]
        public void BuyStock_StockSymbolIsNull()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest();
            buyOrderRequest.StockSymbol = null;
            //Assert
             Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockServices.CreateBuyOrder(buyOrderRequest);
            });

        }

        [Fact]
        public void BuyStock_Valid()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest()
            {
                StockName = "Microsoft",
                StockSymbol = "MSFT",
                Price = 5,
                Quantity = 5,
                DateAndTimeOfOrder = DateTime.Parse("1999-09-09")
            };

            //Act 
            BuyOrderResponse? buyOrderResponse = _stockServices.CreateBuyOrder(buyOrderRequest);

            //Assert
            Assert.True(buyOrderResponse?.BuyOrderID != Guid.Empty);
        }

        #endregion
    }
}