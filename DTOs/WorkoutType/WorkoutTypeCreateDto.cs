using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerApi.DTOs.WorkoutType;

public class WorkoutTypeCreateDto
{
    [Required(ErrorMessage = "Название обязательно!")]
    [MaxLength(100, ErrorMessage = "Максимальная длина 100 символов!")]
    public string Name { get; set; } = string.Empty;
}