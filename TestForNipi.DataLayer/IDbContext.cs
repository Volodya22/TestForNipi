using Microsoft.EntityFrameworkCore;
using TestForNipi.Core.Models;

namespace TestForNipi.DataLayer
{
    /// <summary>
    /// Interface for DI
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Table of cities
        /// </summary>
        DbSet<City> Cities { get; set; }

        /// <summary>
        /// Table of cities locations
        /// </summary>
        DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Table of sections
        /// </summary>
        DbSet<Section> Sections { get; set; }

        /// <summary>
        /// Table of registrations
        /// </summary>
        DbSet<Registration> Registrations { get; set; }

        /// <summary>
        /// Method for data saving
        /// </summary>
        /// <returns>Saving status</returns>
        int SaveChanges();
    }
}
