﻿using FitnessTrackerApi.Models;
using FitnessTrackerApi.Repositories.Interfaces;
using FitnessTrackerApi.Service.Interfaces;

namespace FitnessTrackerApi.Service 
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _repository;
        
        public WorkoutService(IWorkoutRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        public async Task<IEnumerable<Workout>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
        
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
        
        public async Task<Workout> CreateAsync(Workout workout, CancellationToken cancellationToken)
        {
            ValidateWorkout(workout);
            return await _repository.CreateAsync(workout, cancellationToken);
        }
        
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
        
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID должен быть больше нуля", nameof(id));
            }

            return await _repository.DeleteAsync(id, cancellationToken);
        }
        
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