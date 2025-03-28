using Microsoft.EntityFrameworkCore;
using FitnessTrackerApi.Data;
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
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Workouts.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает тренировку по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор тренировки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<Workout?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Workouts.FindAsync(new object[] { id }, cancellationToken);
        }
        /// <summary>
        /// Создаёт новую тренировку.
        /// </summary>
        /// <param name="workout">Объект тренировки для добавления.</param>
        /// <returns>Созданный объект <see cref="Workout"/>.</returns>
        /// <param name="cancellationToken">Токен отмены операции.</param> 
        public async Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync(cancellationToken);
            return workout;
        }
        /// <summary>
        /// Обновляет данные существующей тренировки.
        /// </summary>
        /// <param name="id">Идентификатор тренировки.</param>
        /// <param name="workout">Обновлённый объект тренировки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<bool> UpdateAsync(int id, Workout workout, CancellationToken cancellationToken)
        {
            if (id != workout.Id)
                return false;
            //var existingWorkout = await _context.Workouts.AsNoTracking()
               // .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    
           // if (existingWorkout == null)
              //  return false;                 Спросить про предварительный поиск.

            _context.Entry(workout).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        /// <summary>
        /// Удаляет тренировку по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор тренировки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var workout = await _context.Workouts.FindAsync(new object[] { id }, cancellationToken);
            if (workout == null)
                return false;

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}