using FitnessTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApi.Data.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Workout> Workouts { get; set; }
    DbSet<WorkoutType> WorkoutTypes { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}