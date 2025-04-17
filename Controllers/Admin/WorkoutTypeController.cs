using Microsoft.AspNetCore.Mvc;
using FitnessTrackerApi.Services.Interfaces;
using FitnessTrackerApi.DTOs.WorkoutType;

namespace FitnessTrackerApi.Controllers.Admin;

[Route("api/admin/[controller]")]
    [ApiController]
    public class WorkoutTypeController : ControllerBase
    {
        private readonly IWorkoutTypeService _workoutTypeService;

        public WorkoutTypeController(IWorkoutTypeService workoutTypeService)
        {
            _workoutTypeService = workoutTypeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _workoutTypeService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _workoutTypeService.GetByIdAsync(id, cancellationToken);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(WorkoutTypeCreateDto dto, CancellationToken cancellationToken)
        {
            var created = await _workoutTypeService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, WorkoutTypeUpdateDto dto, CancellationToken cancellationToken)
        {
            var success = await _workoutTypeService.UpdateAsync(id, dto, cancellationToken);
            if (!success)
                return NotFound();

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var success = await _workoutTypeService.DeleteAsync(id, cancellationToken);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }

