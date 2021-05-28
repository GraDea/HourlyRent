using System;
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
        public DbSet<RealtyClient> Clients { get; set; }
        public DbSet<RealtyPrice> Prices { get; set; }
        public DbSet<RealtyBooking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealtyObject>()
                        .HasKey(s => s.Id);
            
           
            modelBuilder.Entity<ObjectImage>()
                        .HasKey(s => s.Id);
            
            
            modelBuilder.Entity<RealtyClient>().ToTable("Clients").HasKey(s => s.Id);
            
            modelBuilder.Entity<RealtyPrice>().ToTable("Prices").HasKey(s => s.Id);
        
            modelBuilder.Entity<RealtyBooking>().ToTable("Bookings").HasKey(s => s.Id);
            
        
            modelBuilder.Entity<RealtyObject>().HasData(
            new RealtyObject[] 
            {
                new RealtyObject { Id=1, Description= "TEst 1", Title= "sadas asdasdasd", ObjectType = ObjectType.Loft },
                new RealtyObject { Id=2, Description= "TEst 1", Title= "asdasdasdasdas", ObjectType = ObjectType.Loft},
                new RealtyObject { Id=3, Description= "TEst 1", Title= "asdasdasdasdas", ObjectType = ObjectType.Loft}
            });
            
            modelBuilder.Entity<RealtyPrice>().HasData(
                new RealtyPrice[] 
                {
                    new RealtyPrice { Id=1, ObjectId= 1, Amount = 1000 },
                    new RealtyPrice { Id=2, ObjectId= 2, Amount = 1000 },
                    new RealtyPrice { Id=3, ObjectId= 2, Amount = 2000, Day = 7},
                    new RealtyPrice { Id=4, ObjectId= 2, Amount = 1000 },
                    new RealtyPrice { Id=5, ObjectId= 3, Amount = 2000, Day = 6},
                    new RealtyPrice { Id=6, ObjectId= 3, Amount = 3000, Day = 7, StartTime = new TimeSpan(12,0,0), EndTime = new TimeSpan(18,0,0)}
                });
            
            modelBuilder.Entity<RealtyClient>().HasData(
                new[] 
                {
                    new RealtyClient { Id=1, Name = "Ssss"}
                });
        }
    }
}