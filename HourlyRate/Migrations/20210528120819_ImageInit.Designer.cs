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
    [Migration("20210528120819_ImageInit")]
    partial class ImageInit
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

            modelBuilder.Entity("HourlyRate.Data.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
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
                            Url = "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Priority = 1,
                            RealtyObjectId = 2,
                            Url = "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Priority = 1,
                            RealtyObjectId = 3,
                            Url = "https://www.pogostite.ru/images/887/409/0/admin/images/conference_places/397/p1ccjm3g6qol31gkf163e1o8t1vni9o.jpg"
                        });
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            Capacity = 100,
                            Description = "Уютный лофт на Бауманской",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ЮЗАО",
                            Title = "Уютный лофт на Бауманской",
                            TotalSpace = 250.0
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 10,
                            Description = "Уютный лофт на Бауманской",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ВАО",
                            Title = "Уютный лофт на Бауманской",
                            TotalSpace = 50.0
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 300,
                            Description = "Уютный лофт на Бауманской",
                            ObjectType = 1,
                            Rating = 5,
                            Region = "ЗАО",
                            Title = "Уютный лофт на Бауманской",
                            TotalSpace = 1000.0
                        });
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

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyObject", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}