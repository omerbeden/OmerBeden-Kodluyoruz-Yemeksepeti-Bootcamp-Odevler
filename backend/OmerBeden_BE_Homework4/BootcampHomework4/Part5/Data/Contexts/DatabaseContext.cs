using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Part5.Data.Entities;

namespace Part5.Data.Contexts
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasKey(k => k.Id);
            modelBuilder.Entity<Drink>().HasKey(d => d.Id);
            modelBuilder.Entity<Menu>().HasKey(m => m.Id);
            modelBuilder.Entity<Restaurant>().HasKey(r => r.Id);
        }
    }
}
