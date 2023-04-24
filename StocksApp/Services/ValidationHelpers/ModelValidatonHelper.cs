using System.ComponentModel.DataAnnotations;

namespace StocksApp.Services.ValidationHelpers
{
    public class ModelValidatonHelper
    {
        /// <summary>
        /// Stock Model Validation helper and throws argument exception
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="ArgumentException" ></exception>
        public static void ModelValidation(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            if(!isValid) 
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
