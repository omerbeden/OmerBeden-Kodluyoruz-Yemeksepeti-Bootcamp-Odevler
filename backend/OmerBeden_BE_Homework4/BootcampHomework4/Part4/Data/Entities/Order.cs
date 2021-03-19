using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part4.Data.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAdress { get; set; }
        public string ShipName { get; set; }
        
    }
}
