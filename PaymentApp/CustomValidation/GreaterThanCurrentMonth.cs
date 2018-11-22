using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.CustomValidation
{
    public class GreaterThanCurrentMonth : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            value = (DateTime)value;
            if(DateTime.Now <= (DateTime)value)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Card has expired");
            }

        }
    }
    
}
