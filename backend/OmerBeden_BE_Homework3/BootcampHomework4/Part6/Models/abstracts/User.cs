using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Part6.Models.abstracts
{
    public abstract class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        
    }
}
