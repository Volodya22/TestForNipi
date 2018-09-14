using System.Collections.Generic;

namespace TestForNipi.Core.Models
{
    /// <summary>
    /// Class for locations data
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Location name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifier of location city
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Corresponding city
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// Sections in this location
        /// </summary>
        public virtual ICollection<Section> Sections { get; set; }
    }
}
