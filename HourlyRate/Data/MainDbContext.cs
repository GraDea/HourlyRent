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
        public DbSet<Service> Services { get; set; }
        

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
            
            modelBuilder.Entity<RealtyObject>()
                        .HasMany(s => s.Prices)
                        .WithOne(t=>t.Object);
            
            modelBuilder.Entity<RealtyObject>()
                        .HasMany(s => s.Bookings)
                        .WithOne(t=>t.Object);
            
            modelBuilder.Entity<RealtyObject>()
                        .HasMany(s => s.AvailableEventTypes)
                        .WithMany(t=>t.Objects);
            
            modelBuilder.Entity<Service>()
                        .ToTable("Services")
                        .HasKey(s => s.Id);
            
            modelBuilder.Entity<RealtyObject>()
                        .HasMany(s => s.Services)
                        .WithMany(t=>t.Objects);
            
            modelBuilder.Entity<EventType>().HasData(
                    new EventType {Id=1,Name = "Митап"},
                    new EventType {Id=2,Name = "Хакатон"},
                    new EventType {Id=3,Name = "Конференция"},
                    new EventType {Id=4,Name = "Мастер-класс"}
                );
            
            modelBuilder.Entity<Service>().HasData(
                new Service {Id=1,Title = "Сцена"},
                new Service {Id=2,Title = "Бар"},
                new Service {Id=3,Title = "Детская зона"},
                new Service {Id=4,Title = "Велком-зона"},
                new Service {Id=5,Title = "Клининг"},
                new Service {Id=6,Title = "Кейтеринг"},
                new Service {Id=7,Title = "Диджей"}
            );
            
            modelBuilder.Entity<RealtyBooking>().ToTable("Bookings").HasKey(s => s.Id);

            modelBuilder.Entity<RealtyObject>().HasData(new RealtyObject
                                                        {
                                                            Id = 1,
                                                            Description = "Легко разместит 150-200 человек театральной рассадкой, а проектор, предназначенный специально для светлых помещений четко и ярко продемонстрирует все подготовленные презентационные материалы.", 
                                                            Title = "Белый зал", 
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "ЦАО",
                                                            Rating = 5,
                                                            Capacity = 20 , 
                                                            TotalSpace = 150,
                                                            Address = "Моховая, д. 12"
                                                        },
                                                        new RealtyObject
                                                        {
                                                            Id = 2, 
                                                            Description = "Обустроенное и комфортабельное пространство подходит для любых бизнес- и образовательных мероприятий: бизнес встречи, презентации, конференции, тренинги, семинары, мастер классы. Любое из них пройдёт на высшем уровне.",
                                                            Title = "Конференц-зал Восток Центр",
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "ВАО",
                                                            Rating = 5, 
                                                            Capacity = 60, 
                                                            TotalSpace = 78,
                                                            Address = "Измайловская, д. 1"
                                                        },
                                                        new RealtyObject
                                                        {
                                                            Id = 3, 
                                                            Description = "Новейший лофт в самом центре Москвы с отдельным парадным входом и панорамными окнами. Специально построен для качественного и комфортного проведения клиентских мероприятий любых форматов.", 
                                                            Title = "PLART", 
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "САО", 
                                                            Rating = 5, 
                                                            Capacity = 20, 
                                                            TotalSpace = 50,
                                                            Address = "Изумрудная д. 23"
                                                        },
                                                        new RealtyObject
                                                        {
                                                            Id = 4, 
                                                            Description = @"Уютный лофт с кухней для проведения праздников, съемок, мастер-классов, вечеринок. Проводим мастер-классы по готовке от именитых шеф-поваров и гастронамические баталии!
                                                            Поможем с организацией вашего мероприятия: подбором шеф-повара, согласованием меню, подбором интерактивного наполнения праздника.
                                                            ", 
                                                            Title = "Петух в вине", 
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "ЗАО", 
                                                            Rating = 5, 
                                                            Capacity = 20, 
                                                            TotalSpace = 50,
                                                            Address = "Митинское шоссе, д. 23"
                                                            
                                                        },
                                                        new RealtyObject
                                                        {
                                                            Id = 5, 
                                                            Description = "Жан Бодрийяр утверждал, что зеркало придает пространству завершенность... А мы придаем завершенность Вашему празднику", 
                                                            Title = "Арт-пространство в Измаильском кремле", 
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "ЮЗАО", 
                                                            Rating = 5, 
                                                            Capacity = 50, 
                                                            TotalSpace = 110,
                                                            Address = "Большая Черемушкинская, д. 5"
                                                        },
                                                        new RealtyObject
                                                        {
                                                            Id = 6, 
                                                            Description = "Студия для виртуальных и онлайн-мероприятий с полным сопровождением. Среди наших клиентов Роскомос, Сбербанк, Тинькофф, Первый канал.", 
                                                            Title = "Duo Screen", 
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "ЮВАО", 
                                                            Rating = 5, 
                                                            Capacity = 50, 
                                                            TotalSpace = 150,
                                                            Address = "Кубанская, д. 23"
                                                        },
                                                        new RealtyObject
                                                        {
                                                            Id = 7, 
                                                            Description = "Хотите устроить вечеринку, посиделки с друзьями за любимой видеоигрой или уединённое свидание под любимый фильм на большом экране? Добро пожаловать в антикинотеатр «Дубль Три». Бронируйте любую из трёх тематических комнат и отдыхайте так, как вам нравится!", 
                                                            Title = "Антикинотеатр \"Дубль Три\"", 
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "ЮЗАО", 
                                                            Rating = 5, 
                                                            Capacity = 30, 
                                                            TotalSpace = 90,
                                                            Address = "Профсоюзная, д. 1"
                                                        },
                                                        new RealtyObject
                                                        {
                                                            Id = 8, 
                                                            Description = "Мы — большое, атмосферное, стильное пространство, созданное для проведения самых по истине крутых вечеринок, фотосессий, лекций, мастер-классов, дней рождения, свадеб и много другого.", 
                                                            Title = "Garden", 
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "ЮАО", 
                                                            Rating = 5, 
                                                            Capacity = 50, 
                                                            TotalSpace = 230,
                                                            Address = "Нахимовский проспект, д. 44"
                                                        },
                                                        new RealtyObject
                                                        {
                                                            Id = 9, 
                                                            Description = "Лофт-кальянная с караоке, с профессиональными концертным музоборудованием. Уютный квартирный интерьер с барной зоной, подготовленный по звуку и климату для проведения домашних концертов, караоке вечеринок, фуршетов и праздников в теплой компании с дымными кальянами.", 
                                                            Title = "Кальян-бар", 
                                                            ObjectType = ObjectType.Loft,
                                                            Region = "СЗАО", 
                                                            Rating = 5, 
                                                            Capacity = 20, 
                                                            TotalSpace = 50,
                                                            Address = "Аэродромная, д. 11"
                                                        });
            

            modelBuilder.Entity<RealtyPrice>().HasData(
                new RealtyPrice[] 
                {
                    new RealtyPrice { Id=1, ObjectId= 1, Amount = 5000 },
                    new RealtyPrice { Id=2, ObjectId= 2, Amount = 5000 },
                    new RealtyPrice { Id=3, ObjectId= 3, Amount = 6000 },
                    new RealtyPrice { Id=4, ObjectId= 4, Amount = 4000 },
                    new RealtyPrice { Id=5, ObjectId= 5, Amount = 3000 },
                    new RealtyPrice { Id=6, ObjectId= 6, Amount = 10000 },
                    new RealtyPrice { Id=7, ObjectId= 7, Amount = 8000 },
                    new RealtyPrice { Id=8, ObjectId= 8, Amount = 2000 },
                    new RealtyPrice { Id=9, ObjectId= 9, Amount = 1000 }
                });
            
            modelBuilder.Entity<RealtyClient>().HasData(
                new[] 
                {
                    new RealtyClient { Id=1, Name = "Ssss"}
                });
           
            
            modelBuilder.Entity<ObjectImage>().HasData(
                new ObjectImage()
                {
                    Id = 1, 
                    RealtyObjectId = 1,
                    Url = "https://www.loft2rent.ru/upload_data/2021/9738/upld8RaD9b.jpg.1200x800.jpg", 
                    Priority = 1
                },
                
                new ObjectImage()
                {
                    Id = 2,
                    RealtyObjectId = 2,
                    Url = "https://www.loft2rent.ru/upload_data/2021/5926/upldevJpmc.JPG.1200x800.jpg",
                    Priority = 1
                },
                new ObjectImage()
                {
                    Id = 3,
                    RealtyObjectId = 3,
                    Url = "https://www.loft2rent.ru/upload_data/2020/9920/upldkN6dzo.jpg.900x600.jpg", 
                    Priority = 1
                },
                new ObjectImage()
                {
                    Id = 4,
                    RealtyObjectId = 4,
                    Url = "https://bash.today/storage/uploads/spaces/2781/lg_c5d3d727-db85-4ee4-92e9-03028d0fb6c0.jpeg", 
                    Priority = 1
                },
                new ObjectImage()
                {
                    Id = 5,
                    RealtyObjectId = 5,
                    Url = "https://bash.today/storage/uploads/spaces/3822/lg_a9c3bf4c-a095-4acc-8b7c-57f95363eb2c.jpg", 
                    Priority = 1
                },
                new ObjectImage()
                {
                    Id = 6,
                    RealtyObjectId = 6,
                    Url = "https://bash.today/storage/uploads/spaces/3736/lg_e94a6ee7-b38f-42b4-add6-85c593ba73d5.jpg", 
                    Priority = 1
                },
                new ObjectImage()
                {
                    Id = 7,
                    RealtyObjectId = 7,
                    Url = "https://bash.today/storage/uploads/spaces/4072/lg_b4cc1dbe-6049-4221-8f88-ada08964eb53.jpeg", 
                    Priority = 1
                },
                new ObjectImage()
                {
                    Id = 8,
                    RealtyObjectId = 8,
                    Url = "https://www.loft2rent.ru/upload_data/2020/2200/upldyLoMLy.jpg.900x600.jpg", 
                    Priority = 1
                },
                new ObjectImage()
                {
                    Id = 9,
                    RealtyObjectId = 9,
                    Url = "https://www.loft2rent.ru/upload_data/2020/2200/upldyLoMLy.jpg.900x600.jpg", 
                    Priority = 1
                }
            );
        }
    }
}