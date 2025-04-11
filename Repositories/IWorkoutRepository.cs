using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.Repositories;

/// <summary>
/// Интерфейс репозитория для работы с тренировками.
/// </summary>
public interface IWorkoutRepository
{
    /// <summary>
    /// Получает все тренировки.
    /// </summary>
    Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает тренировку по её ID.
    /// </summary>
    Task<Workout?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет новую тренировку.
    /// </summary>
    Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновляет существующую тренировку.
    /// </summary>
    Task<bool> UpdateAsync(int id, Workout workout, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет тренировку по ID.
    /// </summary>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    
}