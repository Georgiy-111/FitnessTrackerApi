using Microsoft.EntityFrameworkCore;
using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<Workout> Workouts { get; set; }
    }
}