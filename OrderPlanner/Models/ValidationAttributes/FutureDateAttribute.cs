using System.ComponentModel.DataAnnotations;

namespace OrderPlanner.Models.ValidationAttributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => "Введите дату в будущем";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;
            var date = order.PickupDate;
            
            if (date < DateOnly.FromDateTime(DateTime.Now))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
