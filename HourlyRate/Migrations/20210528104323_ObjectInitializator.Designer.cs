﻿// <auto-generated />
using HourlyRate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HourlyRate.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210528104323_ObjectInitializator")]
    partial class ObjectInitializator
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
                            Title = "asdasdasdasdas"
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
#pragma warning restore 612, 618
        }
    }
}
