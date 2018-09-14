using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForNipi.DataLayer;
using TestForNipi.Web.Models;

namespace TestForNipi.Web.Controllers
{
    /// <summary>
    /// Controller for getting information about locations
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IDbContext _context;

        public LocationController(IDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get a list of locations of a chosen city
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("{name}")]
        [HttpGet]
        public IEnumerable<DataViewModel> Get([FromRoute] string name)
        {
            return _context.Locations.Include(l => l.City).Where(l => l.City.Name == name).ProjectTo<DataViewModel>()
                .ToList();
        }
    }
}