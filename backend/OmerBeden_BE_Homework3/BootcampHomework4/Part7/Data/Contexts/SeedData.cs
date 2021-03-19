using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Part7.Data.Contexts;
using Part7.Data.Entities;

namespace Part7.Data.Seed
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddSampleData(service.GetRequiredService<DatabaseContext>());
        }

        private static async Task AddSampleData(DatabaseContext dbContext)
        {
            if (dbContext.Books.Any())
            {
                return;
            }

            dbContext.Books.Add(new Book
            {
                Id = 1,
                Author = "ömer",
                Name = "Asp.net Core maceraları",
                Publisher = "Kodluyoruz"
            });

            dbContext.Books.Add(new Book
            {
                Id = 2,
                Author = "ömer",
                Name = "gelişim",
                Publisher = "Kodluyoruz"
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
