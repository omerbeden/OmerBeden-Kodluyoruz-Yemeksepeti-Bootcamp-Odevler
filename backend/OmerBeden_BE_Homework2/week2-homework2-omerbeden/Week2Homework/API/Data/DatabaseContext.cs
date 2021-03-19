using ChessAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessAPI.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Title> Titles { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Title>()
        //        .HasDiscriminator<int>("discriminator")
        //        .HasValue<Title>(1)
        //        .HasValue<Noob>(2)
        //        .HasValue<GrandMaster>(3)
        //        .HasValue<InternationalMaster>(4)
        //        .HasValue<FideMaster>(5)
        //        .HasValue<CandidateMaster>(6);
        //}
    }
}
