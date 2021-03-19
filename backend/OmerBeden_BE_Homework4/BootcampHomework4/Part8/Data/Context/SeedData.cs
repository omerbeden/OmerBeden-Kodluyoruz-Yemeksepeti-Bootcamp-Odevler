using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Part8.Data.Entities;

namespace Part8.Data.Context
{
    public static class SeedData
    {

        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddSampleData(service.GetRequiredService<HotelApiDbContext>());
        }

        public static async Task AddSampleData(HotelApiDbContext dbContext)
        {
            if (dbContext.Rooms.Any())
            {
                return;
            }
            
            dbContext.Rooms.Add(new RoomEntity
            {
                Id = Guid.NewGuid(),
                IsMigrate = false,
                Name = "Standart",
                Rate = 648
            });

            dbContext.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("a88cdd16-f627-4f95-95c3-783b7c0554aa"),
                Name = "Suid Oda",
                Rate = 34524,
                IsMigrate = false
            });
            
            

            if (dbContext.Users.Any())
            {
                return;
            }

            dbContext.Users.Add(new UserEntity
            {
                Id = 1,
                Name = "ömer",
                LoginName = "ob",
                Password = "1234",
                Phone = "+90xdxxxxxx",
                SurName = "beden"
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
