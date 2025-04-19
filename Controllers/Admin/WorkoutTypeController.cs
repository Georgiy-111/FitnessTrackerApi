using Microsoft.AspNetCore.Mvc;
using FitnessTrackerApi.Services.Interfaces;
using FitnessTrackerApi.DTOs.WorkoutType;
using AutoMapper;
using FitnessTrackerApi.RequestModels;

namespace FitnessTrackerApi.Controllers.Admin;

/// <summary>
/// Контроллер для управления типами тренировок в админской части приложения.
/// </summary>
[Route("api/admin/[controller]")]
[ApiController]
public class WorkoutTypeController : ControllerBase
{
    private readonly IWorkoutTypeService _workoutTypeService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера типов тренировок.
    /// </summary>
    /// <param name="workoutTypeService">Сервис для работы с типами тренировок.</param>
    /// <param name="mapper">Маппер для преобразования данных.</param>
    public WorkoutTypeController(IWorkoutTypeService workoutTypeService, IMapper mapper)
    {
        _workoutTypeService = workoutTypeService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить список всех типов тренировок.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список типов тренировок.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WorkoutTypeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(typeof(WorkoutTypeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    /// <param name="model">Данные для создания типа тренировки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданный тип тренировки.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(WorkoutTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create(
        [FromBody] WorkoutTypeCreateRequestModel model,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var dto = _mapper.Map<WorkoutTypeCreateDto>(model);
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var success = await _workoutTypeService.DeleteAsync(id, cancellationToken);
        if (!success)
            return NotFound();

        return NoContent();
    }
}