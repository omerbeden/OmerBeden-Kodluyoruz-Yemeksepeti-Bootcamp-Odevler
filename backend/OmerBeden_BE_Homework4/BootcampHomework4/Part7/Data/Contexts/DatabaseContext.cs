using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Part7.Data.Entities;

namespace Part7.Data.Contexts
{
    public class DatabaseContext:DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

    }
}
