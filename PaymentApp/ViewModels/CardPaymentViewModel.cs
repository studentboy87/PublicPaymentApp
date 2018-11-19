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
        [Required, CreditCard]
        public int CardNumberString { get; set; }

        //public int CardNumber => int.Parse(CardNumberString);
        [Required]
        public string CardOwnersName { get; set; }
        public AddressViewModel CardAddress { get; set; }

    }
}
