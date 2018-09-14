using Microsoft.EntityFrameworkCore;
using TestForNipi.Core.Models;

namespace TestForNipi.DataLayer
{
    /// <summary>
    /// Database class
    /// </summary>
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        { }

        /// <summary>
        /// Table of cities
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Table of cities locations
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Table of sections
        /// </summary>
        public DbSet<Section> Sections { get; set; }

        /// <summary>
        /// Table of registrations
        /// </summary>
        public DbSet<Registration> Registrations { get; set; }

        /// <summary>
        /// Initial data creation
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // creating cities
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Moscow"
                },
                new City
                {
                    Id = 2,
                    Name = "Saint-Petersburg"
                },
                new City
                {
                    Id = 3,
                    Name = "Tomsk"
                }
            );

            // creating locations
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "Mira Ave 16, 550",
                    CityId = 1
                },
                new Location
                {
                    Id = 2,
                    Name = "Mira Ave 32, 301",
                    CityId = 1
                },
                new Location
                {
                    Id = 3,
                    Name = "Nevsky Ave 64, 112",
                    CityId = 2
                },
                new Location
                {
                    Id = 4,
                    Name = "Nevsky Ave 128, 50",
                    CityId = 2
                },
                new Location
                {
                    Id = 5,
                    Name = "Lenina Ave 2, 404",
                    CityId = 3
                },
                new Location
                {
                    Id = 6,
                    Name = "Lenina Ave 30, 206",
                    CityId = 3
                }
            );

            // creating sections
            modelBuilder.Entity<Section>().HasData(
                new Section
                {
                    Id = 1,
                    Name = "Geoinformation Systems",
                    ShortName = "GS",
                    LocationId = 1
                },
                new Section
                {
                    Id = 2,
                    Name = "Computer Science",
                    ShortName = "CS",
                    LocationId = 5
                }
            );
        }
    }
}
