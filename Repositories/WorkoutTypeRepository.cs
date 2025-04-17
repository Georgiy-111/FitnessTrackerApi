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

        public async Task<IEnumerable<WorkoutType>> GetAllAsync()
        {
            return await _context.WorkoutTypes.ToListAsync();
        }

        public async Task<WorkoutType?> GetByIdAsync(int id)
        {
            return await _context.WorkoutTypes.FindAsync(id);
        }

        public async Task<WorkoutType> CreateAsync(WorkoutType entity)
        {
            _context.WorkoutTypes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(WorkoutType entity)
        {
            _context.WorkoutTypes.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(WorkoutType entity)
        {
            _context.WorkoutTypes.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}