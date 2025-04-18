using FitnessTrackerApi.DTOs.WorkoutType;

namespace FitnessTrackerApi.Services.Interfaces;

/// <summary>
/// Интерфейс для управления типами тренировок.
/// Определяет основные CRUD-операции для работы с сущностью WorkoutType.
/// </summary>
public interface IWorkoutTypeService
{
    /// <summary>
    /// Получает все типы тренировок.
    /// </summary>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<IEnumerable<WorkoutTypeDto>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получает тип тренировки по её ID.
    /// </summary>
    /// <param name="id">Идентификатор типа тренировки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<WorkoutTypeDto?> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Добавляет новый тип тренировки.
    /// </summary>
    /// <param name="dto">Объект типа тренировки для добавления.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<WorkoutTypeDto> CreateAsync(WorkoutTypeCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет существующий тип тренировки.
    /// </summary>
    /// <param name="id">Идентификатор обновляемого типа тренировки.</param>
    /// <param name="dto">Обновлённая информация о типе тренировки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<bool> UpdateAsync(int id, WorkoutTypeUpdateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет тип тренировки по ID.
    /// </summary>
    /// <param name="id">Идентификатор типа тренировки, который нужно удалить.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}