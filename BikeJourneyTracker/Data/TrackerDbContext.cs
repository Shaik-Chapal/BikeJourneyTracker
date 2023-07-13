using Microsoft.EntityFrameworkCore;

namespace BikeJourneyTracker.Data
{
    public class TrackerDbContext : DbContext
    {
        public TrackerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Journey> Journeys { get; set; }
    }
}
