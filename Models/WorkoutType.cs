using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerApi.Models;

public class WorkoutType
{
    public int Id { get; set; }
    
    [MaxLength(100, ErrorMessage = "Максимальная длина 100 символов!")]
    public string Name { get; set; } = string.Empty;
    
   // public ICollection<WorkoutSchedule> WorkoutSchedules { get; set; } = new List<WorkoutSchedule>();
}