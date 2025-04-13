using FitnessTrackerApi.Data;
using FitnessTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApi.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly ApplicationDbContext _context;
    
    /// <param name="context">Экземпляр контекста базы данных <see cref="ApplicationDbContext"/>.</param>
    public WorkoutRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Список всех тренировок.</returns>
    public async Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Workouts
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
    
    /// <param name="id">Идентификатор тренировки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Тренировка с указанным идентификатором или <c>null</c>, если тренировка не найдена.</returns>
    public async Task<Workout?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Workouts
            .AsNoTracking()
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    }
    
    /// <param name="workout">Объект тренировки для добавления в базу данных.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Созданная тренировка с её данными.</returns>
    public async Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync(cancellationToken);
        return workout;
    }
    
    /// <param name="id">Идентификатор тренировки, которую нужно обновить.</param>
    /// <param name="workout">Обновлённая информация о тренировке.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
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
    
    /// <param name="id">Идентификатор тренировки, которую нужно удалить.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
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