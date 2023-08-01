﻿// <auto-generated />
using System;
using BikeJourneyTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BikeJourneyTracker.Migrations
{
    [DbContext(typeof(TrackerDbContext))]
    partial class TrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BikeJourneyTracker.Journey", b =>
                {
                    b.Property<int>("CoveredDistance")
                        .HasColumnType("int");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartureStationId")
                        .HasColumnType("int");

                    b.Property<string>("DepartureStationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationSec")
                        .HasColumnType("int");

                    b.Property<DateTime>("Return")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReturnStationId")
                        .HasColumnType("int");

                    b.Property<string>("ReturnStationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Journeys");
                });

            modelBuilder.Entity("BikeJourneyTracker.Station", b =>
                {
                    b.Property<int>("FID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FID"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("Kapasiteet")
                        .HasColumnType("int");

                    b.Property<string>("Kaupunki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operaattor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Osoite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("x")
                        .HasColumnType("float");

                    b.Property<double>("y")
                        .HasColumnType("float");

                    b.HasKey("FID");

                    b.ToTable("Stations");
                });
#pragma warning restore 612, 618
        }
    }
}
