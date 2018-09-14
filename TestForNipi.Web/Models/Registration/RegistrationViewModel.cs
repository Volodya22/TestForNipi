using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TestForNipi.Web.Models.Registration
{
    /// <summary>
    /// Class for passing registration data
    /// </summary>
    public class RegistrationViewModel
    {
        /// <summary>
        /// Chosen section identifier
        /// </summary>
        [HiddenInput]
        public int SectionId { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }
    }
}
