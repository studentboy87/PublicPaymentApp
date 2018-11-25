using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Models
{
    public class Customer
    {
        public int ID { get; set; }
        //Other relevant fields would go here

        public virtual Address Address { get; set; }
        public virtual ICollection<RegisteredCard> RegisteredCards { get; set; }
    }
}
