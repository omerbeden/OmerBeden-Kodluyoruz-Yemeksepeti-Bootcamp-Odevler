using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Part2.Data.Entities;

namespace Part2.Data.Contexts
{
    public class DatabaseContext:DbContext
    {

        public DatabaseContext(DbContextOptions options):base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        
    }
}
