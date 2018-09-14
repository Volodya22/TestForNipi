﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestForNipi.DataLayer;

namespace TestForNipi.DataLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180913144856_InitialDataAdded")]
    partial class InitialDataAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestForNipi.Core.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new { Id = 1, Name = "Moscow" },
                        new { Id = 2, Name = "Saint-Petersburg" },
                        new { Id = 3, Name = "Tomsk" }
                    );
                });

            modelBuilder.Entity("TestForNipi.Core.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Locations");

                    b.HasData(
                        new { Id = 1, CityId = 1, Name = "Mira Ave 16, 550" },
                        new { Id = 2, CityId = 1, Name = "Mira Ave 32, 301" },
                        new { Id = 3, CityId = 2, Name = "Nevsky Ave 64, 112" },
                        new { Id = 4, CityId = 2, Name = "Nevsky Ave 128, 50" },
                        new { Id = 5, CityId = 3, Name = "Lenina Ave 2, 404" },
                        new { Id = 6, CityId = 3, Name = "Lenina Ave 30, 206" }
                    );
                });

            modelBuilder.Entity("TestForNipi.Core.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Sections");

                    b.HasData(
                        new { Id = 1, LocationId = 1, Name = "Geoinformation Systems", ShortName = "GIS" },
                        new { Id = 2, LocationId = 5, Name = "Computer Science", ShortName = "CS" }
                    );
                });

            modelBuilder.Entity("TestForNipi.Core.Models.Location", b =>
                {
                    b.HasOne("TestForNipi.Core.Models.City", "City")
                        .WithMany("Locations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestForNipi.Core.Models.Section", b =>
                {
                    b.HasOne("TestForNipi.Core.Models.Location", "Location")
                        .WithMany("Sections")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
