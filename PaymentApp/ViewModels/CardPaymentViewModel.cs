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
        [CreditCard(ErrorMessage ="This is not correct")]
        public string CardNumberString { get; set; }

        //public int CardNumber => int.Parse(CardNumberString);
        [Required]
        public string CardOwnersName { get; set; }
        public AddressViewModel CardAddress { get; set; }

    }
}
