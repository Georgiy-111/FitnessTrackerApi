using FitnessTrackerApi.Models;
using FitnessTrackerApi.Repositories;

namespace FitnessTrackerApi.Service 
{
    
    /// <summary>
    /// Сервис для работы с тренировками.
    /// Отвечает за выполнение операций CRUD (создание, чтение, обновление, удаление) с тренировками.
    /// </summary>
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _repository;
        
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WorkoutService"/>.
        /// </summary>
        public WorkoutService(IWorkoutRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        /// <returns>Список тренировок <see cref="Workout"/>.</returns>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
        
        /// <param name="id">Идентификатор тренировки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<Workout?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                return null;
            }
            
            var workout = await _repository.GetByIdAsync(id, cancellationToken);

            if (workout == null)
            {
                throw new KeyNotFoundException("Тренировка не найдена или была удалена");
            }
            
            return workout;
        }
        
        /// <param name="workout">Объект тренировки для добавления.</param>
        /// <returns>Созданный объект <see cref="Workout"/>.</returns>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken)
        {
            ValidateWorkout(workout);
            return await _repository.CreateAsync(workout, cancellationToken);
        }
        
        /// <param name="id">Идентификатор тренировки.</param>
        /// <param name="workout">Обновлённый объект тренировки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<bool> UpdateAsync(int id, Workout workout, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID должен быть больше нуля", nameof(id));  
            }

            if (id != workout.Id)
            {
                throw new ArgumentException("ID тренировки не совпадает", nameof(id));
            }

            ValidateWorkout(workout);
            
            var existingWorkout = await _repository.GetByIdAsync(id, cancellationToken);
            
            if (existingWorkout == null)
            {
                throw new KeyNotFoundException("Тренировка не найдена или была удалена");
            }

            return await _repository.UpdateAsync(id, workout, cancellationToken);
        }
        
        /// <param name="id">Идентификатор тренировки.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID должен быть больше нуля", nameof(id));
            }

            return await _repository.DeleteAsync(id, cancellationToken);
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