using Microsoft.AspNetCore.Mvc;
using FitnessTrackerApi.Services.Interfaces;
using FitnessTrackerApi.DTOs.WorkoutType;

namespace FitnessTrackerApi.Controllers.Admin;

[Route("api/admin/[controller]")]
[ApiController]
public class WorkoutTypeController : ControllerBase
{
    private readonly IWorkoutTypeService _workoutTypeService;

    /// <summary>
    /// Конструктор контроллера типов тренировок.
    /// </summary>
    /// <param name="workoutTypeService">Сервис для работы с типами тренировок.</param>
    public WorkoutTypeController(IWorkoutTypeService workoutTypeService)
    {
        _workoutTypeService = workoutTypeService;
    }

    /// <summary>
    /// Получить список всех типов тренировок.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список типов тренировок.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _workoutTypeService.GetAllAsync(cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить тип тренировки по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор типа тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Тип тренировки или 404, если не найден.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _workoutTypeService.GetByIdAsync(id, cancellationToken);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Создать новый тип тренировки.
    /// </summary>
    /// <param name="dto">Данные для создания типа тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданный тип тренировки.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(WorkoutTypeCreateDto dto, CancellationToken cancellationToken)
    {
        var created = await _workoutTypeService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Обновить существующий тип тренировки.
    /// </summary>
    /// <param name="id">Идентификатор типа тренировки.</param>
    /// <param name="dto">Обновлённые данные типа тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Результат выполнения операции.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, WorkoutTypeUpdateDto dto, CancellationToken cancellationToken)
    {
        var success = await _workoutTypeService.UpdateAsync(id, dto, cancellationToken);
        if (!success)
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Удалить тип тренировки по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор типа тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Результат выполнения операции.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var success = await _workoutTypeService.DeleteAsync(id, cancellationToken);
        if (!success)
            return NotFound();

        return NoContent();
    }
}