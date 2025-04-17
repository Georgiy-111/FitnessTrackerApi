using Microsoft.AspNetCore.Mvc;
using FitnessTrackerApi.Models;
using FitnessTrackerApi.Service.Interfaces;

namespace FitnessTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;
    
/// <param name="workoutService">Сервис для работы с тренировками.</param>
    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

/// <returns>Список тренировок.</returns>
/// <param name="cancellationToken">Токен отмены операции.</param>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts(CancellationToken cancellationToken)
    {
        var workouts = await _workoutService.GetAllAsync(cancellationToken);
        return Ok(workouts);
    }

/// <param name="id">Идентификатор тренировки.</param>
/// <returns>Тренировка или ошибка 404, если не найдена.</returns>
/// <param name="cancellationToken">Токен отмены операции.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<Workout>> GetWorkout(int id, CancellationToken cancellationToken)
    {
        var workout = await _workoutService.GetByIdAsync(id, cancellationToken);
        if (workout == null)
            return NotFound();

        return Ok(workout);
    }

/// <param name="workout">Объект тренировки.</param>
/// <returns>Созданная тренировка с её ID.</returns>
/// <param name="cancellationToken">Токен отмены операции.</param>
    [HttpPost]
    public async Task<ActionResult<Workout>> CreateWorkout(Workout workout, CancellationToken cancellationToken)
    {
        var createdWorkout = await _workoutService.CreateAsync(workout, cancellationToken);
        return CreatedAtAction(nameof(GetWorkout), new { id = createdWorkout.Id }, createdWorkout);
    }

/// <param name="id">Идентификатор тренировки.</param>
/// <param name="workout">Обновлённые данные тренировки.</param>
/// <returns>Результат операции (204 No Content или 400 Bad Request).</returns>
/// <param name="cancellationToken">Токен отмены операции.</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkout(int id, Workout workout, CancellationToken cancellationToken)
    {
        var success = await _workoutService.UpdateAsync(id, workout, cancellationToken);
        if (!success)
            return BadRequest();

        return NoContent();
    }

/// <param name="id">Идентификатор тренировки.</param>
/// <returns>Результат операции (204 No Content или 404 Not Found).</returns>
/// <param name="cancellationToken">Токен отмены операции.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkout(int id, CancellationToken cancellationToken)
    {
        var success = await _workoutService.DeleteAsync(id, cancellationToken);
        if (!success)
            return NotFound();

        return NoContent();
    }
}