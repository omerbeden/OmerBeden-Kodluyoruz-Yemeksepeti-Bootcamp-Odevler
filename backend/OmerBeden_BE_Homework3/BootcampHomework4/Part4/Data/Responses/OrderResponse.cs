using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part4.Data.Entities;

namespace Part4.Data.Responses
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public CustomerResponse Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShipAdress { get; set; }

        public string ShipName { get; set; }
    }
}
