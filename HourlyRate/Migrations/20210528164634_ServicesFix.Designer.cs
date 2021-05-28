﻿// <auto-generated />
using System;
using HourlyRate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HourlyRate.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210528164634_ServicesFix")]
    partial class ServicesFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventTypeRealtyObject", b =>
                {
                    b.Property<int>("AvailableEventTypesId")
                        .HasColumnType("int");

                    b.Property<int>("ObjectsId")
                        .HasColumnType("int");

                    b.HasKey("AvailableEventTypesId", "ObjectsId");

                    b.HasIndex("ObjectsId");

                    b.ToTable("EventTypeRealtyObject");
                });

            modelBuilder.Entity("HourlyRate.Data.Models.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Митап"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Хакатон"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Конференция"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Мастер-класс"
                        });
                });

            modelBuilder.Entity("HourlyRate.Data.Models.ObjectImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("RealtyObjectId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RealtyObjectId");

                    b.ToTable("ObjectImage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Priority = 1,
                            RealtyObjectId = 1,
                            Url = "https://www.loft2rent.ru/upload_data/2021/9738/upld8RaD9b.jpg.1200x800.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Priority = 1,
                            RealtyObjectId = 2,
                            Url = "https://www.loft2rent.ru/upload_data/2021/5926/upldevJpmc.JPG.1200x800.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Priority = 1,
                            RealtyObjectId = 3,
                            Url = "https://www.loft2rent.ru/upload_data/2020/9920/upldkN6dzo.jpg.900x600.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Priority = 1,
                            RealtyObjectId = 4,
                            Url = "https://bash.today/storage/uploads/spaces/2781/lg_c5d3d727-db85-4ee4-92e9-03028d0fb6c0.jpeg"
                        },
                        new
                        {
                            Id = 5,
                            Priority = 1,
                            RealtyObjectId = 5,
                            Url = "https://bash.today/storage/uploads/spaces/3822/lg_a9c3bf4c-a095-4acc-8b7c-57f95363eb2c.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Priority = 1,
                            RealtyObjectId = 6,
                            Url = "https://bash.today/storage/uploads/spaces/3736/lg_e94a6ee7-b38f-42b4-add6-85c593ba73d5.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Priority = 1,
                            RealtyObjectId = 7,
                            Url = "https://bash.today/storage/uploads/spaces/4072/lg_b4cc1dbe-6049-4221-8f88-ada08964eb53.jpeg"
                        },
                        new
                        {
                            Id = 8,
                            Priority = 1,
                            RealtyObjectId = 8,
                            Url = "https://www.loft2rent.ru/upload_data/2020/2200/upldyLoMLy.jpg.900x600.jpg"
                        },
                        new
                        {
                            Id = 9,
                            Priority = 1,
                            RealtyObjectId = 9,
                            Url = "https://www.loft2rent.ru/upload_data/2020/2200/upldyLoMLy.jpg.900x600.jpg"
                        });
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ObjectId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ssss"
                        });
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Lon")
                        .HasColumnType("float");

                    b.Property<int>("ObjectType")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalSpace")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Objects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Моховая, д. 12",
                            Capacity = 20,
                            Description = "Легко разместит 150-200 человек театральной рассадкой, а проектор, предназначенный специально для светлых помещений четко и ярко продемонстрирует все подготовленные презентационные материалы.",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ЦАО",
                            Title = "Белый зал",
                            TotalSpace = 150.0
                        },
                        new
                        {
                            Id = 2,
                            Address = "Измайловская, д. 1",
                            Capacity = 60,
                            Description = "Обустроенное и комфортабельное пространство подходит для любых бизнес- и образовательных мероприятий: бизнес встречи, презентации, конференции, тренинги, семинары, мастер классы. Любое из них пройдёт на высшем уровне.",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ВАО",
                            Title = "Конференц-зал Восток Центр",
                            TotalSpace = 78.0
                        },
                        new
                        {
                            Id = 3,
                            Address = "Изумрудная д. 23",
                            Capacity = 20,
                            Description = "Новейший лофт в самом центре Москвы с отдельным парадным входом и панорамными окнами. Специально построен для качественного и комфортного проведения клиентских мероприятий любых форматов.",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "САО",
                            Title = "PLART",
                            TotalSpace = 50.0
                        },
                        new
                        {
                            Id = 4,
                            Address = "Митинское шоссе, д. 23",
                            Capacity = 20,
                            Description = "Уютный лофт с кухней для проведения праздников, съемок, мастер-классов, вечеринок. Проводим мастер-классы по готовке от именитых шеф-поваров и гастронамические баталии!\r\n                                                            Поможем с организацией вашего мероприятия: подбором шеф-повара, согласованием меню, подбором интерактивного наполнения праздника.\r\n                                                            ",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ЗАО",
                            Title = "Петух в вине",
                            TotalSpace = 50.0
                        },
                        new
                        {
                            Id = 5,
                            Address = "Большая Черемушкинская, д. 5",
                            Capacity = 50,
                            Description = "Жан Бодрийяр утверждал, что зеркало придает пространству завершенность... А мы придаем завершенность Вашему празднику",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ЮЗАО",
                            Title = "Арт-пространство в Измаильском кремле",
                            TotalSpace = 110.0
                        },
                        new
                        {
                            Id = 6,
                            Address = "Кубанская, д. 23",
                            Capacity = 50,
                            Description = "Студия для виртуальных и онлайн-мероприятий с полным сопровождением. Среди наших клиентов Роскомос, Сбербанк, Тинькофф, Первый канал.",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ЮВАО",
                            Title = "Duo Screen",
                            TotalSpace = 150.0
                        },
                        new
                        {
                            Id = 7,
                            Address = "Профсоюзная, д. 1",
                            Capacity = 30,
                            Description = "Хотите устроить вечеринку, посиделки с друзьями за любимой видеоигрой или уединённое свидание под любимый фильм на большом экране? Добро пожаловать в антикинотеатр «Дубль Три». Бронируйте любую из трёх тематических комнат и отдыхайте так, как вам нравится!",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ЮЗАО",
                            Title = "Антикинотеатр \"Дубль Три\"",
                            TotalSpace = 90.0
                        },
                        new
                        {
                            Id = 8,
                            Address = "Нахимовский проспект, д. 44",
                            Capacity = 50,
                            Description = "Мы — большое, атмосферное, стильное пространство, созданное для проведения самых по истине крутых вечеринок, фотосессий, лекций, мастер-классов, дней рождения, свадеб и много другого.",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ЮАО",
                            Title = "Garden",
                            TotalSpace = 230.0
                        },
                        new
                        {
                            Id = 9,
                            Address = "Аэродромная, д. 11",
                            Capacity = 20,
                            Description = "Лофт-кальянная с караоке, с профессиональными концертным музоборудованием. Уютный квартирный интерьер с барной зоной, подготовленный по звуку и климату для проведения домашних концертов, караоке вечеринок, фуршетов и праздников в теплой компании с дымными кальянами.",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "СЗАО",
                            Title = "Кальян-бар",
                            TotalSpace = 50.0
                        });
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.ToTable("Prices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 5000m,
                            ObjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 5000m,
                            ObjectId = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = 6000m,
                            ObjectId = 2
                        },
                        new
                        {
                            Id = 4,
                            Amount = 4000m,
                            ObjectId = 2
                        },
                        new
                        {
                            Id = 5,
                            Amount = 3000m,
                            ObjectId = 2
                        },
                        new
                        {
                            Id = 6,
                            Amount = 10000m,
                            ObjectId = 2
                        },
                        new
                        {
                            Id = 7,
                            Amount = 8000m,
                            ObjectId = 2
                        },
                        new
                        {
                            Id = 8,
                            Amount = 2000m,
                            ObjectId = 2
                        },
                        new
                        {
                            Id = 9,
                            Amount = 1000m,
                            ObjectId = 2
                        });
                });

            modelBuilder.Entity("HourlyRate.Data.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Сцена"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Бар"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Детская зона"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Велком-зона"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Клининг"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Кейтеринг"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Диджей"
                        });
                });

            modelBuilder.Entity("RealtyObjectService", b =>
                {
                    b.Property<int>("ObjectsId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("ObjectsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("RealtyObjectService");
                });

            modelBuilder.Entity("EventTypeRealtyObject", b =>
                {
                    b.HasOne("HourlyRate.Data.Models.EventType", null)
                        .WithMany()
                        .HasForeignKey("AvailableEventTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HourlyRate.Data.Models.RealtyObject", null)
                        .WithMany()
                        .HasForeignKey("ObjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HourlyRate.Data.Models.ObjectImage", b =>
                {
                    b.HasOne("HourlyRate.Data.Models.RealtyObject", null)
                        .WithMany("Images")
                        .HasForeignKey("RealtyObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyBooking", b =>
                {
                    b.HasOne("HourlyRate.Data.Models.RealtyClient", "Client")
                        .WithMany("Bookings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HourlyRate.Data.Models.RealtyObject", "Object")
                        .WithMany("Bookings")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Object");
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyPrice", b =>
                {
                    b.HasOne("HourlyRate.Data.Models.RealtyObject", "Object")
                        .WithMany("Prices")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Object");
                });

            modelBuilder.Entity("RealtyObjectService", b =>
                {
                    b.HasOne("HourlyRate.Data.Models.RealtyObject", null)
                        .WithMany()
                        .HasForeignKey("ObjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HourlyRate.Data.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyClient", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyObject", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Images");

                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}
