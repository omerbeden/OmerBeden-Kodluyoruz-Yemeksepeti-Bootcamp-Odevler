using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part5.Data.Entities
{
    public class Drink:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
