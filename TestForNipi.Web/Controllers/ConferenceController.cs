using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForNipi.Core.Models;
using TestForNipi.DataLayer;
using TestForNipi.Web.Models.Section;

namespace TestForNipi.Web.Controllers
{
    /// <summary>
    /// API controller for CRUD operations with sections
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ConferenceController : ControllerBase
    {
        private readonly IDbContext _context;

        public ConferenceController(IDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get information about all sections
        /// </summary>
        /// <returns>List of all sections</returns>
        [HttpGet("info")]
        public List<SectionViewModel> GetAll()
        {
            return _context.Sections.Include(s => s.Location.City).ToList().Select(s => new SectionViewModel(s)).ToList();
        }

        /// <summary>
        /// Method to get information about chosen section
        /// </summary>
        /// <param name="section"></param>
        /// <returns>Section information</returns>
        [HttpGet("{section}/info")]
        public ActionResult<AddEditSectionViewModel> Get(string section)
        {
            var model = _context.Sections.Include(s => s.Location.City).FirstOrDefault(s => s.ShortName == section);

            // return 404, if sections with such abbreviation is not exist
            if (model == null)
            {
                return NotFound();
            }

            var viewModel = new AddEditSectionViewModel
            {
                City = model.Location.City.Name,
                Location = model.Location.Name,
                Name = model.Name
            };

            return viewModel;
        }

        /// <summary>
        /// Method to create a new section
        /// </summary>
        /// <param name="section">Section abbreviation</param>
        /// <param name="obj">Section data</param>
        /// <returns>Creation status</returns>
        [HttpPost("{section}/info")]
        public IActionResult Post(string section, [FromBody] AddEditSectionViewModel obj)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Name == obj.City);
            var location = _context.Locations.FirstOrDefault(l => l.Name == obj.Location);
            
            // return 400, if data is invalid
            if (city == null || location == null || location.CityId != city.Id)
            {
                return BadRequest();
            }

            var model = _context.Sections.FirstOrDefault(s => s.ShortName == section);

            // create new section, if such section is not exist
            if (model == null)
            {
                var newSection = new Section
                {
                    Name = obj.Name,
                    ShortName = section,
                    LocationId = location.Id
                };

                _context.Sections.Add(newSection);
            }
            // return 400 in other way
            else
            {
                return BadRequest();
            }

            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Method for updating section's information
        /// </summary>
        /// <param name="section">Section abbreviation</param>
        /// <param name="obj">Section data</param>
        /// <returns>Update status</returns>
        [HttpPut("{section}/info")]
        public IActionResult Put([FromRoute] string section, [FromBody] AddEditSectionViewModel obj)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Name == obj.City);
            var location = _context.Locations.FirstOrDefault(l => l.Name == obj.Location);

            // return 400, if data is invalid
            if (city == null || location == null || location.CityId != city.Id)
            {
                return BadRequest();
            }

            var model = _context.Sections.FirstOrDefault(s => s.ShortName == section);

            // if such section is not exist, then create
            if (model == null)
            {
                var newSection = new Section
                {
                    Name = obj.Name,
                    ShortName = section,
                    LocationId = location.Id
                };

                _context.Sections.Add(newSection);
            }
            // update it in other way
            else
            {
                model.Name = obj.Name;
                model.LocationId = location.Id;

                _context.Sections.Update(model);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}