using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PaymentApp.CustomValidation
{
    public class CardExpiryDate : ValidationAttribute, IClientModelValidator
    {
        private readonly string _comparisonProperty;
        public CardExpiryDate(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            if(value == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            var currentValue = DateTime.ParseExact((string)value, "yyyyMMdd", null);
            var endOfTheMonth = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if(endOfTheMonth == null)
            {
                throw new ArgumentException("property is not found");
            }

            var endOfTheMonthValue = (string)endOfTheMonth.GetValue(validationContext.ObjectInstance);
            var endOfTheMonthDateValue = DateTime.ParseExact((string)endOfTheMonthValue, "yyyyMMdd", null);
            if(currentValue < endOfTheMonthDateValue)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            var endOfTheMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToString("yyyyMMdd");
            var error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-error", error);
            context.Attributes.Add("data-val-cardexpirydate", endOfTheMonth);

        }
    }
}
