using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerApi.Models;
/// <summary>
/// Модель данных для тренировки.
/// </summary>
public class Workout
{
    /// <summary>
    /// Уникальный идентификатор тренировки.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название тренировки.
    /// </summary>
    [MaxLength(50, ErrorMessage = "Макс длина 50 символов!")]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Описание тренировки.
    /// </summary>
    [MaxLength(50, ErrorMessage = "Максимальная длина 50 символов!")]
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// Продолжительность тренировки (в минутах).
    /// </summary>
    public int Duration { get; set; }
    /// <summary>
    /// Показывает, было ли удалено данное значение.
    /// </summary>
    public bool IsDeleted { get; set; }
}