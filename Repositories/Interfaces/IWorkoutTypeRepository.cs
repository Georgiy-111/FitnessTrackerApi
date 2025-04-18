using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.Repositories.Interfaces;

/// <summary>
/// Интерфейс для управления типами тренировок.
/// Определяет основные CRUD-операции для работы с сущностью WorkoutType.
/// </summary>
public interface IWorkoutTypeRepository
{
    /// <summary>
    /// Получает все типы тренировок.
    /// </summary>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<IEnumerable<WorkoutType>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получает тип тренировки по её ID.
    /// </summary>
    /// <param name="id">Идентификатор типа тренировки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<WorkoutType?> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Добавляет новый тип тренировки.
    /// </summary>
    /// <param name="entity">Объект типа тренировки для добавления.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<WorkoutType> CreateAsync(WorkoutType entity, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет существующий тип тренировки.
    /// </summary>
    /// <param name="entity">Обновлённая информация о типе тренировки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<bool> UpdateAsync(WorkoutType entity, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет тип тренировки.
    /// </summary>
    /// <param name="entity">Тип тренировки, который нужно удалить.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<bool> DeleteAsync(WorkoutType entity, CancellationToken cancellationToken);
}