using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestForNipi.Core.Models;
using TestForNipi.DataLayer;
using TestForNipi.Web.Models;
using TestForNipi.Web.Models.Registration;
using TestForNipi.Web.Models.Section;

namespace TestForNipi.Web.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller for the main page
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IDbContext _context;

        public HomeController(IDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// View for the main page
        /// </summary>
        /// <returns>Corresponding view</returns>
        public IActionResult Index()
        {
            var sections = _context.Sections.ProjectTo<DataViewModel>().ToList();

            return View(sections);
        }

        /// <summary>
        /// Partial view for the list of sections
        /// </summary>
        /// <returns>Corresponding view</returns>
        public IActionResult List()
        {
            var sections = _context.Sections.ProjectTo<DataViewModel>().ToList();

            return PartialView(sections);
        }

        /// <summary>
        /// Partial view with information about chosen section
        /// </summary>
        /// <param name="id">Section's identifier</param>
        /// <returns>Corresponding view</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Location.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (section == null)
            {
                return NotFound();
            }

            var model = new AddEditSectionViewModel
            {
                City = section.Location.City.Name,
                Location = section.Location.Name,
                Name = section.Name
            };

            return PartialView(model);
        }

        /// <summary>
        /// Partial view with section's creation form
        /// </summary>
        /// <returns>Corresponding view</returns>
        public IActionResult Create()
        {
            ViewData["City"] = new SelectList(_context.Cities, "Name", "Name");
            ViewData["Location"] = new SelectList(_context.Locations.Where(l => l.CityId == 1), "Name", "Name");

            return PartialView();
        }

        /// <summary>
        /// Partial view with section's editing form with corresponding data
        /// </summary>
        /// <param name="id">Section's identifier</param>
        /// <returns>Corresponding view</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections.Include(s => s.Location.City).FirstOrDefaultAsync(s => s.Id == id);
            if (section == null)
            {
                return NotFound();
            }

            var model = new AddEditSectionViewModel
            {
                City = section.Location.City.Name,
                Location = section.Location.Name,
                Name = section.Name
            };

            ViewData["City"] = new SelectList(_context.Cities, "Name", "Name", model.City);
            ViewData["Location"] = new SelectList(_context.Locations.Include(l => l.City).Where(l => l.City.Name == model.City), "Name", "Name", model.Location);

            return PartialView(model);
        }

        /// <summary>
        /// Partial view with registration form
        /// </summary>
        /// <param name="id">Section's identifier</param>
        /// <returns>Corresponding view</returns>
        public IActionResult Register(int id)
        {
            var model = new RegistrationViewModel
            {
                SectionId = id
            };

            return PartialView(model);
        }

        /// <summary>
        /// Method for saving registration data
        /// </summary>
        /// <param name="model">Registration data</param>
        /// <returns>Result of creation</returns>
        [HttpPost]
        public IActionResult Register([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false
                });
            }

            var registration = new Registration
            {
                SectionId = model.SectionId,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Email = model.Email
            };

            _context.Registrations.Add(registration);
            _context.SaveChanges();

            return Json(new
            {
                success = true
            });
        }
    }
}
