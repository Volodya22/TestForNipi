namespace TestForNipi.Core.Models
{
    /// <summary>
    /// Class for sections data
    /// </summary>
    public class Section
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Section abbreviation
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Section name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifier of section location
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Corresponding location
        /// </summary>
        public virtual Location Location { get; set; }
    }
}
