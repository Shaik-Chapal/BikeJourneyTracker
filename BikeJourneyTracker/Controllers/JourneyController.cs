using BikeJourneyTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace BikeJourneyTracker.Controllers
{
    [ApiController]
    [Route("api/[cotroller]")]
    public class JourneyController : Controller
    {
        private readonly TrackerDbContext _trackerDbContext;

        public JourneyController(TrackerDbContext dbContext) { }
        [HttpGet]
        public IActionResult GetJourney()
        {
            return Ok(_trackerDbContext.Journeys.ToList());
            
        }
    }
}
