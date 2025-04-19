using FitnessTrackerApi.DTOs.WorkoutType;
using FitnessTrackerApi.Models;
using FitnessTrackerApi.Repositories.Interfaces;
using FitnessTrackerApi.Services.Interfaces;

namespace FitnessTrackerApi.Services;

public class WorkoutTypeService : IWorkoutTypeService
{
    private readonly IWorkoutTypeRepository _repository;

    public WorkoutTypeService(IWorkoutTypeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<WorkoutTypeDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var types = await _repository.GetAllAsync(cancellationToken);
        return types.Select(x => new WorkoutTypeDto
        {
            Id = x.Id,
            Name = x.Name
        });
    }
    
    public async Task<WorkoutTypeDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity == null) return null;

        return new WorkoutTypeDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    
    public async Task<WorkoutTypeDto> CreateAsync(WorkoutTypeCreateDto dto, CancellationToken cancellationToken)
    {
        var entity = new WorkoutType
        {
            Name = dto.Name
        };

        var created = await _repository.CreateAsync(entity, cancellationToken);

        return new WorkoutTypeDto
        {
            Id = created.Id,
            Name = created.Name
        };
    }
    
    public async Task<bool> UpdateAsync(int id, WorkoutTypeUpdateDto dto, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(id, cancellationToken);
        if (existing == null) return false;

        existing.Name = dto.Name;

        return await _repository.UpdateAsync(existing, cancellationToken);
    }
    
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;

        return await _repository.DeleteAsync(entity, cancellationToken);
    }
}