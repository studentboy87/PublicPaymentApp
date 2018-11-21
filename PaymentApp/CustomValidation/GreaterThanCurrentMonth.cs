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
            /*value = int.Parse((string)value);
            if((int)DateTime.Now.Month >= int.Parse((string)value))
            {
                //be easier to just compare the date...... infact it need to be the date otherwise is only the month it will only compare. 
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("")
            }*/

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
