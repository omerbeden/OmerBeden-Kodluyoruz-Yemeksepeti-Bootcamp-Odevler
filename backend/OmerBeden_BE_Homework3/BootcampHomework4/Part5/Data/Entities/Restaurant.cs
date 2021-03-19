using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part5.Data.Entities
{
    public class Restaurant:IEntity
    {
        public int Id { get; set; }
        public List<Menu> Menus { get; set; }
        public String Name { get; set; }
        public string Adress { get; set; }
        public int Score { get; set; }

    }
}
