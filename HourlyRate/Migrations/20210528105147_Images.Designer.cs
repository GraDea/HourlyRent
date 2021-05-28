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
    [Migration("20210528105147_Images")]
    partial class Images
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("HourlyRate.Data.Models.ObjectImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int?>("RealtyObjectId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RealtyObjectId");

                    b.ToTable("ObjectImage");
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Objects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "TEst 1",
                            ObjectType = 1,
                            Title = "sadas asdasdasd"
                        },
                        new
                        {
                            Id = 2,
                            Description = "TEst 1",
                            ObjectType = 1,
                            Title = "asdasdasdasdas"
                        },
                        new
                        {
                            Id = 3,
                            Description = "TEst 1",
                            ObjectType = 1,
                            Title = "asdasdasdasdas"
                        });
                });

            modelBuilder.Entity("HourlyRate.Data.Models.ObjectImage", b =>
                {
                    b.HasOne("HourlyRate.Data.Models.RealtyObject", null)
                        .WithMany("Images")
                        .HasForeignKey("RealtyObjectId");
                });

            modelBuilder.Entity("HourlyRate.Data.Models.RealtyObject", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}