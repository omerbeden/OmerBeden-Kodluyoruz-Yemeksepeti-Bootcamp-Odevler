using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Part8.Data.Entities;

namespace Part8.Data.Context
{
    public class HotelApiDbContext:DbContext
    {

        public HotelApiDbContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        
    }
}
