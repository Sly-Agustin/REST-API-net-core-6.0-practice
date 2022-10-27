using System.ComponentModel.DataAnnotations;

namespace WebApiCoffeeShop.Validations
{
    public class FirstLetterCapital : ValidationAttribute
    {
        /* Value is the field in the model
         * In validationContext we have the whole representation of the model
         */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            var firstLetter = value.ToString()[0].ToString();
            if (firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("First letter must be a capital letter");
            }
            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
}
