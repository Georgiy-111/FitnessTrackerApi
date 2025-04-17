using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.Repositories.Interfaces;

public interface IWorkoutTypeRepository
{
    Task<IEnumerable<WorkoutType>> GetAllAsync();
    
    Task<WorkoutType?> GetByIdAsync(int id);
    
    Task<WorkoutType> CreateAsync(WorkoutType entity);
    
    Task<bool> UpdateAsync(WorkoutType entity);
    
    Task<bool> DeleteAsync(WorkoutType entity);
}