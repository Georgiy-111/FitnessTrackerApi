using Microsoft.EntityFrameworkCore;
using FitnessTrackerApi.Models;
using FitnessTrackerApi.Data.Interfaces;
    
namespace FitnessTrackerApi.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
        
        public DbSet<Workout> Workouts { get; set; }
        
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
    }
}