
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManager.DTOs;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class Task : Controller
    {
        private readonly ITaskService _taskService;

        private readonly ITaskUserService _taskUserService;

        public Task(ITaskService taskService, ITaskUserService taskUserService)
        {
            _taskService = taskService;
            _taskUserService = taskUserService;
        }

        [HttpGet("getAllTasks")]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("getTaskId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }
            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = new TfaTask
            {
                TaskName = taskDto.TaskName,
                CategoryId = taskDto.CategoryId,
                // Agrega más propiedades si es necesario
            };

            await _taskService.AddAsync(task);

            bool isAssigned = await _taskUserService.AssignTaskToUserAsync(task.TaskId);

            if (!isAssigned)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al asignar la tarea al usuario.");
            }

            return CreatedAtAction(nameof(GetById), new { id = task.TaskId }, task);
        }


        [HttpPut("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto entity)
        {
            // Valida la entrada
            if (entity == null || id != entity.TaskId)
            {
                return BadRequest("Datos inválidos.");
            }

            // Llama al servicio para actualizar
            var result = await _taskService.UpdateAsync(id, entity);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isAssigned = await _taskUserService.DeleteTaskAsync(id);
            var existingTask = await _taskService.GetByIdAsync(id);

            if (!isAssigned && existingTask == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la tarea del usuario.");
            }

            await _taskService.DeleteAsync(id);
            return NoContent();
        }
    }
}
