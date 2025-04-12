using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.Service;

/// <summary>
/// Интерфейс для управления тренировками.
/// Определяет основные CRUD-операции для работы с сущностью Workout.
/// </summary>
public interface IWorkoutService
{
    
    /// <summary>
    /// Получает все тренировки.
    /// </summary>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает тренировку по её ID.
    /// </summary>
    /// <param name="id">Идентификатор тренировки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<Workout?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавляет новую тренировку.
    /// </summary>
    /// <param name="workout">Объект тренировки для добавления.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновляет существующую тренировку.
    /// </summary>
    /// <param name="id">Идентификатор обновляемой тренировки.</param>
    /// <param name="workout">Обновлённая информация о тренировке.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<bool> UpdateAsync(int id, Workout workout, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет тренировку по ID.
    /// </summary>
    /// <param name="id">Идентификатор тренировки, которую нужно удалить.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}