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
        [Display(Name = "Card Number", Prompt = "The 16 digit number across the face of the card")]
        public string CardNumberString { get; set; }

        //public int CardNumber => int.Parse(CardNumberString);
        [Required]
        [Display(Name ="Cardholder's Name", Prompt ="Cardholder's Name")]
        public string CardOwnersName { get; set; }
        public AddressViewModel CardAddress { get; set; }
        [Required]
        public string ExpiryMonth { get; set; }
        [Required]
        public string ExpiryYear { get; set; }


        public string ExpiryDateString => DateTime.DaysInMonth(int.Parse(ExpiryYear), int.Parse(ExpiryMonth)) + "-" + ExpiryMonth + "-" + ExpiryYear;


        public DateTime parsedDate => DateTime.ParseExact(ExpiryDateString, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None);

        //private int asf => DateTime.DaysInMonth()
        /*public DateTime CardExpiryDate => new DateTime(int.Parse(ExpiryYear), int.Parse(ExpiryMonth), DateTime.DaysInMonth(int.Parse(ExpiryYear), int.Parse(ExpiryMonth)), )*/
        //public DateTime test => DateTime.ParseExact(ExpiryDateString, "ddMMyy",);
        //public DateTime test => DateTime.Parse(ExpiryDateString, "ddMMyy");
    }
}
