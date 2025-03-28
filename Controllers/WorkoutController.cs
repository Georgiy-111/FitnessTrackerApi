using Microsoft.AspNetCore.Mvc;
using FitnessTrackerApi.Models;
using FitnessTrackerApi.Services;
namespace FitnessTrackerApi.Controllers;
/// <summary>
/// Контроллер для управления тренировками
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WorkoutController : ControllerBase
{
    private readonly WorkoutService _workoutService;
/// <summary>
/// Инициализирует новый экземпляр 
/// </summary>
/// <param name="workoutService">Сервис для работы с тренировками.</param>
    public WorkoutController(WorkoutService workoutService)
    {
        _workoutService = workoutService;
    }
/// <summary>
/// Получает список всех тренировок.
/// </summary>
/// <returns>Список тренировок.</returns>
/// <param name="cancellationToken">Токен отмены операции.</param>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts(CancellationToken cancellationToken)
    {
        var workouts = await _workoutService.GetAllAsync(cancellationToken);
        return Ok(workouts);
    }
/// <summary>
/// Получает информацию о тренировке по её идентификатору.
/// </summary>
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
/// <summary>
/// Создаёт новую тренировку.
/// </summary>
/// <param name="workout">Объект тренировки.</param>
/// <returns>Созданная тренировка с её ID.</returns>
/// <param name="cancellationToken">Токен отмены операции.</param>
    [HttpPost]
    public async Task<ActionResult<Workout>> CreateWorkout(Workout workout, CancellationToken cancellationToken)
    {
        var createdWorkout = await _workoutService.CreateAsync(workout, cancellationToken);
        return CreatedAtAction(nameof(GetWorkout), new { id = createdWorkout.Id }, createdWorkout);
    }
/// <summary>
/// Обновляет тренировку.
/// </summary>
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
/// <summary>
/// Удаляет тренировку по идентификатору.
/// </summary>
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