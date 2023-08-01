using BikeJourneyTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

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


        [HttpGet("popular-return-stations")]
        public async Task<IActionResult> GetPopularReturnStations(int topN = 5)
        {
            var popularReturnStations = await _trackerDbContext.Stations
                .Select(station => new
                {
                    StationId = station.ID,
                    StationName = station.Name,
                    Popularity = _trackerDbContext.Journeys
                        .Count(journey => journey.ReturnStationId== station.ID)
                })
                .OrderByDescending(station => station.Popularity)
                .Take(topN)
                .ToListAsync();

            return Ok(popularReturnStations);
        }

        [HttpGet("popular-departure-stations")]
        public async Task<IActionResult> GetPopularDepartureStations(int topN = 5)
        {
            var popularDepartureStations = await _trackerDbContext.Stations
                .Select(station => new
                {
                    StationId = station.ID,
                    StationName = station.Name,
                    Popularity = _trackerDbContext.Journeys
                        .Count(journey => journey.DepartureStationId == station.ID)
                })
                .OrderByDescending(station => station.Popularity)
                .Take(topN)
                .ToListAsync();

            return Ok(popularDepartureStations);
        }


        [HttpGet("average-distance-ending")]
        public async Task<IActionResult> GetAverageDistanceEndingAtStation(int stationId)
        {
            var averageDistanceEnding = await _trackerDbContext.Journeys
                .Where(journey => journey.ReturnStationId == stationId)
                .AverageAsync(journey => journey.CoveredDistance);

            return Ok(averageDistanceEnding);
        }

        [HttpGet("search-by-letter")]
        public async Task<IActionResult> SearchStationsByLetter(char startingLetter)
        {
            // Convert the starting letter to uppercase for case-insensitive search
            startingLetter = char.ToUpper(startingLetter);

            var matchingStations = await _trackerDbContext.Stations
                .Where(station => char.ToUpper(station.Nimi[0]) == startingLetter)
                .ToListAsync();

            return Ok(matchingStations);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchStations(string query, int pageNumber = 1, int pageSize = 10)
        {
            if (string.IsNullOrEmpty(query))
                return BadRequest("Please provide a valid search query.");

            var matchingStations = await _trackerDbContext.Stations
                .AsQueryable()
                .Where(station => station.Nimi != null && station.Nimi.ToLower().Contains(query.ToLower()))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(matchingStations);
        }

        [HttpGet("all-nimi-list")]
        public async Task<IActionResult> GetAllNimiList()
        {
            var nimiList = await _trackerDbContext.Stations
                .Select(station => station.Nimi)
                .Distinct()
                .ToListAsync();

            return Ok(nimiList);
        }






    }

}
//https://localhost:7182/api/Journey?pageSize=10&pageNumber=1