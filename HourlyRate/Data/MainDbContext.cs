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
            
        
            modelBuilder.Entity<RealtyObject>().HasData(new RealtyObject { Id=1, Description= "Уютный лофт на Бауманской", Title= "Уютный лофт на Бауманской", ObjectType = ObjectType.Loft, Region = "ЮЗАО", Rating = 5, Capacity = 100, TotalSpace = 250},
                                                        new RealtyObject { Id=2, Description= "Уютный лофт на Бауманской", Title= "Уютный лофт на Бауманской", ObjectType = ObjectType.Loft, Region = "ВАО", Rating = 5, Capacity = 10, TotalSpace = 50},
                                                        new RealtyObject { Id=3, Description= "Уютный лофт на Бауманской", Title= "Уютный лофт на Бауманской", ObjectType = ObjectType.Loft, Region = "ЗАО", Rating = 5, Capacity = 300, TotalSpace = 1000});
            
           
        }
    }
}