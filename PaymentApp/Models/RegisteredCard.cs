using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Models
{
    public class RegisteredCard
    {
        public int ID { get; set; }
        public int CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime CardExpiryDate { get; set; }
        public int CustomerID { get; set; }
        public int AddressID { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }

        
    }
}
