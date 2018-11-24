using PaymentApp.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.ViewModels
{
    public class CardPaymentViewModel
    {
        [Required]
        [CreditCard]
        [StringLength(16, MinimumLength =16)]
        [Display(Name = "Card Number", Prompt = "The 16 digit number across the face of the card")]
        public string CardNumberString { get; set; }
//add int cardnumber

        [Required]
        [Display(Name ="Cardholder's Name", Prompt ="Cardholder's Name")]
        public string CardOwnersName { get; set; }
        public AddressViewModel CardAddress { get; set; }
        [Required]
        public string ExpiryMonth { get; set; }
        [Required]
        public string ExpiryYear { get; set; }

        [Required]
        [CardExpiryDate("EndOfTheCurrentMonth", ErrorMessage ="Card has Expired2")]
        public string CardExpiryDate { get; set; }

        //public DateTime EndOfTheCurrentMonth { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        public string EndOfTheCurrentMonth { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToString("yyyyMMdd");


        public string ExpiryDateString => DateTime.DaysInMonth(int.Parse(ExpiryYear), int.Parse(ExpiryMonth)) + "-" + ExpiryMonth + "-" + ExpiryYear;


        [GreaterThanCurrentMonth]
        public DateTime ExpiryDate => DateTime.ParseExact(ExpiryDateString, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None);

    }
}
