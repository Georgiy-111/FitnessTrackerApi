using FitnessTrackerApi.DTOs.WorkoutType;

namespace FitnessTrackerApi.Services.Interfaces;

public interface IWorkoutTypeService
{
    Task<IEnumerable<WorkoutTypeDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<WorkoutTypeDto?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<WorkoutTypeDto> CreateAsync(WorkoutTypeCreateDto dto, CancellationToken cancellationToken);

    Task<bool> UpdateAsync(int id, WorkoutTypeUpdateDto dto, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}