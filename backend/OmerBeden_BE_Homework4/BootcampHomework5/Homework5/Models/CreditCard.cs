using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5.Models
{

    public class CreditCard
    {
        public int CreditCardID { get; set; }
        public string CardType { get; set; }
        public long CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
    
}
