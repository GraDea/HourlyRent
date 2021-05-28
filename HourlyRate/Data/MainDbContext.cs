using HourlyRate.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }


        public virtual DbSet<RealtyObject> Objects { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealtyObject>()
                        .HasKey(s => s.Id);
            
            modelBuilder.Entity<RealtyObject>()
                        .HasMany(s => s.Images);
            
            modelBuilder.Entity<ObjectImage>()
                        .HasKey(s => s.Id);
            
            
            modelBuilder.Entity<Client>().ToTable("Client").HasKey(s => s.Id);; 
        
        
            modelBuilder.Entity<RealtyObject>().HasData(
            new RealtyObject[] 
            {
                new RealtyObject { Id=1, Description= "TEst 1", Title= "sadas asdasdasd", ObjectType = ObjectType.Loft },
                new RealtyObject { Id=2, Description= "TEst 1", Title= "asdasdasdasdas", ObjectType = ObjectType.Loft},
                new RealtyObject { Id=3, Description= "TEst 1", Title= "asdasdasdasdas", ObjectType = ObjectType.Loft}
            });
        }
    }
}