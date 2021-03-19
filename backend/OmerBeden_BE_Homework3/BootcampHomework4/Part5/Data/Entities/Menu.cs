using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part5.Data.Entities
{
    public class Menu:IEntity
    {
        public int Id { get; set; }
        public List<Drink> Drinks { get; set; }
        public List<Food> Foods { get; set; }
        public string Name { get; set; }
        
        
    }
}
