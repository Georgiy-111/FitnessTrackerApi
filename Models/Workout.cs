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
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Описание тренировки.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// Продолжительность тренировки (в минутах).
    /// </summary>
    public int Duration { get; set; } 
}