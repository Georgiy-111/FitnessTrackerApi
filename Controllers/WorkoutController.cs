using Microsoft.AspNetCore.Mvc;
using FitnessTrackerApi.Models;
using FitnessTrackerApi.Service.Interfaces;

namespace FitnessTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    /// <summary>
    /// Конструктор контроллера для работы с тренировками.
    /// </summary>
    /// <param name="workoutService">Сервис для управления тренировками.</param>
    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    /// <summary>
    /// Получить список всех тренировок.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список тренировок.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts(CancellationToken cancellationToken)
    {
        var workouts = await _workoutService.GetAllAsync(cancellationToken);
        return Ok(workouts);
    }

    /// <summary>
    /// Получить тренировку по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Тренировка или 404, если не найдена.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Workout>> GetWorkout(int id, CancellationToken cancellationToken)
    {
        var workout = await _workoutService.GetByIdAsync(id, cancellationToken);
        if (workout == null)
            return NotFound();

        return Ok(workout);
    }

    /// <summary>
    /// Создать новую тренировку.
    /// </summary>
    /// <param name="workout">Объект тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданная тренировка с её идентификатором.</returns>
    [HttpPost]
    public async Task<ActionResult<Workout>> CreateWorkout(Workout workout, CancellationToken cancellationToken)
    {
        var createdWorkout = await _workoutService.CreateAsync(workout, cancellationToken);
        return CreatedAtAction(nameof(GetWorkout), new { id = createdWorkout.Id }, createdWorkout);
    }

    /// <summary>
    /// Обновить существующую тренировку.
    /// </summary>
    /// <param name="id">Идентификатор тренировки.</param>
    /// <param name="workout">Обновлённые данные тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Результат выполнения операции (204 или 400).</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkout(int id, Workout workout, CancellationToken cancellationToken)
    {
        var success = await _workoutService.UpdateAsync(id, workout, cancellationToken);
        if (!success)
            return BadRequest();

        return NoContent();
    }

    /// <summary>
    /// Удалить тренировку по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Результат выполнения операции (204 или 404).</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkout(int id, CancellationToken cancellationToken)
    {
        var success = await _workoutService.DeleteAsync(id, cancellationToken);
        if (!success)
            return NotFound();

        return NoContent();
    }
}