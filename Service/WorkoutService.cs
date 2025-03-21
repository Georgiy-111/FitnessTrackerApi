using Microsoft.EntityFrameworkCore;
using FitnessTrackerApi.data;
using FitnessTrackerApi.Models;
using FitnessTrackerApi.Services;

namespace FitnessTrackerApi.Services 
{
    /// <summary>
    /// Сервис для работы с тренировками.
    /// Отвечает за выполнение операций CRUD (создание, чтение, обновление, удаление) с тренировками.
    /// </summary>
    public class WorkoutService
    {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WorkoutService"/>.
        /// </summary>
        /// <param name="context">Экземпляр <see cref="ApplicationDbContext"/> для взаимодействия с базой данных.</param>
        public WorkoutService(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех тренировок.
        /// </summary>
        /// <returns>Список тренировок <see cref="Workout"/>.</returns>
        public async Task<IEnumerable<Workout>> GetAllAsync()
        {
            return await _context.Workouts.ToListAsync();
        }
        /// <summary>
        /// Получает тренировку по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор тренировки.</param>
        public async Task<Workout?> GetByIdAsync(int id)
        {
            return await _context.Workouts.FindAsync(id);
        }
        /// <summary>
        /// Создаёт новую тренировку.
        /// </summary>
        /// <param name="workout">Объект тренировки для добавления.</param>
        /// <returns>Созданный объект <see cref="Workout"/>.</returns>
        public async Task<Workout> CreateAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return workout;
        }
        /// <summary>
        /// Обновляет данные существующей тренировки.
        /// </summary>
        /// <param name="id">Идентификатор тренировки.</param>
        /// <param name="workout">Обновлённый объект тренировки.</param>
        public async Task<bool> UpdateAsync(int id, Workout workout)
        {
            if (id != workout.Id)
                return false;

            _context.Entry(workout).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// Удаляет тренировку по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор тренировки.</param>
        public async Task<bool> DeleteAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
                return false;

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}