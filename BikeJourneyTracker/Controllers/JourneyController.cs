using BikeJourneyTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeJourneyTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JourneyController : Controller
    {
        private readonly TrackerDbContext _trackerDbContext;

        public JourneyController(TrackerDbContext dbContext)
        {
            this._trackerDbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetJourney(int pageSize = 10, int pageNumber = 1)
        {
            var totalItems = await _trackerDbContext.Journeys.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var journeys = await _trackerDbContext.Journeys
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var response = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Journeys = journeys
            };

            return Ok(response);
        }


        [HttpGet("stations")]
        public async Task<IActionResult> GetStations(int pageSize = 10, int pageNumber = 1)
        {
            var totalItems = await _trackerDbContext.Stations.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var stations = await _trackerDbContext.Stations
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var response = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Stations = stations
            };

            return Ok(response);
        }





    }

}
//https://localhost:7182/api/Journey?pageSize=10&pageNumber=1