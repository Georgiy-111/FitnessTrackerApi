using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerApi.Models;

public class Workout
{
    public int Id { get; set; }
    
    [MaxLength(500, ErrorMessage = "Макс длина 500 символов!")]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(500, ErrorMessage = "Максимальная длина 500 символов!")]
    public string Description { get; set; } = string.Empty;
    
    public int Duration { get; set; }
}