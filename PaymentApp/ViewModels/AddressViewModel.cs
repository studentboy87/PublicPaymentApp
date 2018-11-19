using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "Cardholder's address is required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Cardholder's address is required")]
        public string Town { get; set; }
        public string County { get; set; }
        [Required(ErrorMessage = "Cardholder's address is required")]
        public string Postcode { get; set; }
    }
}
