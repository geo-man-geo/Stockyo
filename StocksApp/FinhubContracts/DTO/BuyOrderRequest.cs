using StocksApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace StocksApp.FinhubContracts.DTO
{
    public class BuyOrderRequest
    {
        [Required(ErrorMessage = "StockSymbol is mandatory")]
        public string? StockSymbol { get; set; }

        [Required(ErrorMessage = "StockName is mandatory")]
        public string? StockName { get; set; }

        [CustomValidation(typeof(BuyOrderRequest), "ValidateBuyingOrderDate")]
        public DateTime? DateAndTimeOfOrder { get; set; }

        [Range(1, 10000, ErrorMessage = "The {0} field must be between {1} and {2}.")]
        public uint? Quantity { get; set; }

        [Range(1, 10000, ErrorMessage = "The {0} field must be between {1} and {2}.")]
        public double? Price { get; set; }


        // Custom Validation
        public static ValidationResult ValidateBuyingOrderDate(DateTime? DateAndTimeOfOrder, ValidationContext? context)
        {
            DateTime maxDate = new DateTime(2000, 1, 1);
            if (DateAndTimeOfOrder > maxDate)
            {
                return new ValidationResult("The DateAndTimeOfOrder field must be a date not older than 01/01/2000.");
            }

            return ValidationResult.Success;
        }

        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder
            {
                StockSymbol = StockSymbol,
                StockName = StockName,
                DateAndTimeOfOrder = DateAndTimeOfOrder,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}
