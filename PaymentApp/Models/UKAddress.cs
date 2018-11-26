using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Models
{
    public class UKAddress : Address
    {
        public string County { get; set; }
        public string Postcode { get; set; }
    }
}
