namespace TestForNipi.Core.Models
{
    /// <summary>
    /// Class for registration data
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Chosen section
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        public string Email { get; set; }
    }
}
