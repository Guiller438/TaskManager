
//using Microsoft.AspNetCore.Mvc;
//using TaskManager.DTOs;
//using TaskManager.Models;
//using TaskManager.Services;

//namespace TaskManager.Controllers
//{

//    [ApiController]
//    [Route("api/[controller]")]
//    public class Task : Controller
//    {
//        private readonly ITaskService _taskService;

//        public Task(ITaskService taskService)
//        {
//            _taskService = taskService;
//        }

//        [HttpGet("getAllTasks")]
//        public async Task<IActionResult> GetAll()
//        {
//            var tasks = await _taskService.GetAllAsync();
//            return Ok(tasks);
//        }

//        [HttpGet("getTaskId/{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var task = await _taskService.GetByIdAsync(id);
//            if (task == null)
//            {
//                return NotFound($"Task with ID {id} not found.");
//            }
//            return Ok(task);
//        }

//        [HttpPost("CreateTask")]
//        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var task = new TfaTask
//            {
//                TaskName = taskDto.TaskName,
//                CategoryId = taskDto.CategoryId,
//            };

//            await _taskService.AddAsync(task);


//            return CreatedAtAction(nameof(GetById), new { id = task.TaskId }, task);
//        }


//        [HttpPut("UpdateTask/{id}")]
//        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto entity)
//        {
//            // Valida la entrada
//            if (entity == null || id != entity.TaskId)
//            {
//                return BadRequest("Datos inválidos.");
//            }

//            // Llama al servicio para actualizar
//            var result = await _taskService.UpdateAsync(id, entity);

//            if (!result)
//            {
//                return NotFound();
//            }

//            return NoContent();
//        }


//        [HttpDelete("DeleteTask/{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var existingTask = await _taskService.GetByIdAsync(id);
//            if (existingTask == null)
//            {
//                return NotFound($"Task with ID {id} not found.");
//            }

//            await _taskService.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}

