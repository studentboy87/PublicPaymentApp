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
        [Display(Prompt ="Address line one")]
        public string AddressLine1 { get; set; }
        [Display(Prompt = "Address line two")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Cardholder's address is required")]
        [Display(Prompt ="Town")]
        public string Town { get; set; }
        [Display(Prompt ="County")]
        public string County { get; set; }

        [Required(ErrorMessage = "Cardholder's address is required")]
        [Display(Prompt ="AA12 2YZ")]
        public string Postcode { get; set; }
    }
}
