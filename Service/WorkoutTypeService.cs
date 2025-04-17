using FitnessTrackerApi.DTOs.WorkoutType;
using FitnessTrackerApi.Models;
using FitnessTrackerApi.Services.Interfaces;
using FitnessTrackerApi.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApi.Services;

public class WorkoutTypeService : IWorkoutTypeService
{
    private readonly IApplicationDbContext _context;

    public WorkoutTypeService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkoutTypeDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.WorkoutTypes
            .Select(x => new WorkoutTypeDto
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<WorkoutTypeDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkoutTypes
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (entity == null)
        {
            return null;
        }

        return new WorkoutTypeDto()
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
        _context.WorkoutTypes.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new WorkoutTypeDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    
    public async Task<bool> UpdateAsync(int id, WorkoutTypeUpdateDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkoutTypes
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return false;
        }

        entity.Name = dto.Name;
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _context.WorkoutTypes
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return false;
        }
        
        _context.WorkoutTypes.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}