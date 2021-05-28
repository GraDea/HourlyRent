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

        public DbSet<ObjectImage> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealtyObject>()
                        .HasKey(s => s.Id);

            modelBuilder.Entity<RealtyObject>()
                        .HasMany(s => s.Images);
            
            
            
           
            modelBuilder.Entity<ObjectImage>()
                        .ToTable("ObjectImage")
                        .HasKey(s => s.Id);
            
            modelBuilder.Entity<RealtyClient>().ToTable("Clients").HasKey(s => s.Id);
            
            modelBuilder.Entity<RealtyPrice>().ToTable("Prices").HasKey(s => s.Id);
        
            modelBuilder.Entity<EventType>()
                        .HasKey(s => s.Id);
            
            modelBuilder.Entity<RealtyObject>()
                        .HasMany(s => s.AvailableEventTypes)
                        .WithMany(t=>t.Objects);
            
            modelBuilder.Entity<EventType>().HasData(
                    new EventType {Id=1,Name = "Митап"},
                    new EventType {Id=2,Name = "Хакатон"},
                    new EventType {Id=3,Name = "Конференция"},
                    new EventType {Id=4,Name = "Мастер-класс"}
                );
            
            modelBuilder.Entity<RealtyBooking>().ToTable("Bookings").HasKey(s => s.Id);
            
            modelBuilder.Entity<RealtyObject>().HasData(new RealtyObject { Id=1, Description= "Уютный лофт на Бауманской", Title= "Уютный лофт на Бауманской", ObjectType = ObjectType.Loft, Region = "ЮЗАО", Rating = 5, Capacity = 100, TotalSpace = 250},
                                                        new RealtyObject { Id=2, Description= "Уютный лофт на Бауманской", Title= "Уютный лофт на Бауманской", ObjectType = ObjectType.Loft, Region = "ВАО", Rating = 5, Capacity = 10, TotalSpace = 50},
                                                        new RealtyObject { Id=3, Description= "Уютный лофт на Бауманской", Title= "Уютный лофт на Бауманской", ObjectType = ObjectType.Loft, Region = "ЗАО", Rating = 5, Capacity = 300, TotalSpace = 1000});
            

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
           
            
            modelBuilder.Entity<ObjectImage>().HasData(
                new ObjectImage(){ Id = 1, RealtyObjectId = 1, Url = "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg", Priority = 1},
                new ObjectImage(){ Id = 2, RealtyObjectId = 2, Url = "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg", Priority = 1},
                new ObjectImage(){ Id = 3, RealtyObjectId = 3, Url = "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg", Priority = 1}
            );
           
        }
    }
}