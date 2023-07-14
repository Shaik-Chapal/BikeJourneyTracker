using Microsoft.EntityFrameworkCore;

namespace BikeJourneyTracker.Data
{
    public class TrackerDbContext : DbContext
    {
        public TrackerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journey>().HasNoKey();
           
        }

        public DbSet<Journey> Journeys { get; set; }
    }
}
