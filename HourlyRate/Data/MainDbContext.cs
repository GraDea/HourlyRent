using HourlyRate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }


        public virtual DbSet<RealtyObject> Objects { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealtyObject>()
                        .HasKey(s => s.Id);
            modelBuilder.Entity<Client>().ToTable("Client").HasKey(s => s.Id);; }
    }
}