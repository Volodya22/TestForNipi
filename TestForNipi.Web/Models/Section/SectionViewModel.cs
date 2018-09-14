namespace TestForNipi.Web.Models.Section
{
    /// <summary>
    /// Class for sending information about section
    /// </summary>
    public class SectionViewModel
    {
        public SectionViewModel(Core.Models.Section section)
        {
            Section = section.ShortName;

            Info = new AddEditSectionViewModel
            {
                City = section.Location.City.Name,
                Location = section.Location.Name,
                Name = section.Name
            };
        }

        /// <summary>
        /// Section abbreviation
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Main information about section
        /// </summary>
        public AddEditSectionViewModel Info { get; set; }
    }
}
