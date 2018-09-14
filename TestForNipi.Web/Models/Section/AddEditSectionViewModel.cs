using System.ComponentModel.DataAnnotations;

namespace TestForNipi.Web.Models.Section
{
    /// <summary>
    /// Class for passing data, when creating or updating section
    /// </summary>
    public class AddEditSectionViewModel
    {
        /// <summary>
        /// Section name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// City where section has place
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Location where section has place
        /// </summary>
        public string Location { get; set; }
    }
}
