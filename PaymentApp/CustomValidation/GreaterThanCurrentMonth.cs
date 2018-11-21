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
            value = int.Parse((string)value);
            if((int)DateTime.Now.Month >= value.value)
            {
                //be easier to just compare the date......
            }
        }
    }
    
}
