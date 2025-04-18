using FitnessTrackerApi.Models;
using FitnessTrackerApi.Data;
using FitnessTrackerApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApi.Repositories
{
    public class WorkoutTypeRepository : IWorkoutTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkoutTypeRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkoutType>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.WorkoutTypes.ToListAsync(cancellationToken);
        }

        public async Task<WorkoutType?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.WorkoutTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
        }

        public async Task<WorkoutType> CreateAsync(WorkoutType entity, CancellationToken cancellationToken)
        {
            _context.WorkoutTypes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<bool> UpdateAsync(WorkoutType entity, CancellationToken cancellationToken)
        {
            _context.WorkoutTypes.Update(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteAsync(WorkoutType entity, CancellationToken cancellationToken)
        {
            _context.WorkoutTypes.Remove(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}