using System.Collections.Generic;

namespace TestForNipi.Core.Models
{
    /// <summary>
    /// Class for cities data
    /// </summary>
    public class City
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// City locations
        /// </summary>
        public virtual ICollection<Location> Locations { get; set; }
    }
}
