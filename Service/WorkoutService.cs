using FitnessTrackerApi.Data;
using FitnessTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApi.Service 
{
    
    /// <summary>
    /// Сервис для работы с тренировками.
    /// Отвечает за выполнение операций CRUD (создание, чтение, обновление, удаление) с тренировками.
    /// </summary>
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext _context;
        
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WorkoutService"/>.
        /// </summary>
        /// <param name="context">Экземпляр <see cref="ApplicationDbContext"/> для взаимодействия с базой данных.</param>
        public WorkoutService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        /// <summary>
        /// Получает список всех тренировок.
        /// </summary>
        /// <returns>Список тренировок <see cref="Workout"/>.</returns>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Workouts
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        
        /// <summary>
        /// Получает тренировку по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор тренировки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<Workout?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID должен быть больше нуля", nameof(id));
            }
            return await _context.Workouts
                .SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
        }
        
        /// <summary>
        /// Создаёт новую тренировку.
        /// </summary>
        /// <param name="workout">Объект тренировки для добавления.</param>
        /// <returns>Созданный объект <see cref="Workout"/>.</returns>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken)
        {
            ValidateWorkout(workout);
            
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
            {
                throw new ArgumentException("ID тренировки не совпадает", nameof(id));
            }
            
            var existingWorkout = await _context.Workouts
                .SingleOrDefaultAsync(w => w.Id == id, cancellationToken);

            if (existingWorkout == null)
            {
                throw new KeyNotFoundException("Тренировка не найдена или была удалена");
            }
            
            _context.Entry(existingWorkout).CurrentValues.SetValues(workout);
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
            if (id <= 0)
            {
                throw new ArgumentException("ID должен быть больше нуля", nameof(id));
            }
            
            var workout = await _context.Workouts
                .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
            
            if (workout == null)
                return false;
            
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        
/// <summary>
/// Проверяет корректность данных тренировки
/// </summary>
/// <param name="workout"></param>
/// <exception cref="ArgumentNullException"></exception>
        private static void ValidateWorkout(Workout workout)
        {
            if (workout == null)
            {
                throw new ArgumentNullException(nameof(workout),"Объект тренировки не может быть null");
            }
            if (string.IsNullOrWhiteSpace(workout.Name))
            {
                throw new ArgumentException("Название тренировки не может быть пустым", nameof(workout.Name));
            }
            if (string.IsNullOrWhiteSpace(workout.Description))
            {
                throw new ArgumentException("Описание тренировки не может быть пустым", nameof(workout.Description));
            }
            if (workout.Duration <= 0)
            {
                throw new ArgumentException("Продолжительность тренировки должна быть больше нуля", nameof(workout.Duration));
            }
        }
    }
}