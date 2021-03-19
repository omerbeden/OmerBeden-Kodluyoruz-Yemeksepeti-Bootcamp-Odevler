using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part4.Data.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
}
