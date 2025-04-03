using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.Service;

/// <summary>
/// Интерфейс для управления тренировками.
/// Определяет основные CRUD-операции для работы с сущностью Workout.
/// </summary>
public interface IWorkoutService
{
    Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken);
    Task<Workout?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(int id, Workout workout, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
}