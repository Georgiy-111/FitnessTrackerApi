using FitnessTrackerApi.Data;
using FitnessTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerApi.Repositories.Interfaces;

namespace FitnessTrackerApi.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly ApplicationDbContext _context;
    
    public WorkoutRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Workouts
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    public async Task<Workout?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Workouts
            .AsNoTracking()
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    }
    
    public async Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync(cancellationToken);
        return workout;
    }
    
    public async Task<bool> UpdateAsync(int id, Workout workout, CancellationToken cancellationToken)
    {
        if (id != workout.Id)
            return false;

        var existingWorkout = await _context.Workouts
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

        if (existingWorkout == null)
            return false;

        _context.Entry(existingWorkout).CurrentValues.SetValues(workout);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var workout = await _context.Workouts
            .SingleOrDefaultAsync(w => w.Id == id, cancellationToken);

        if (workout == null)
            return false;

        _context.Workouts.Remove(workout);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}