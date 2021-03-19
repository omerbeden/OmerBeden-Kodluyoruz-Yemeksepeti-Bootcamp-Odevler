using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part7.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}
