using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTaskController : ControllerBase
    {
        private readonly ITaskUserService _userTaskService;

        public UserTaskController(ITaskUserService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        // GET: api/UserTask
        [HttpGet]
        public async Task<IActionResult> GetAllUserTasks()
        {
            var userTasks = await _userTaskService.GetAllAsync();
            return Ok(userTasks);
        }

        // GET: api/UserTask/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTaskById(int id)
        {
            var userTask = await _userTaskService.GetByIdAsync(id);
            if (userTask == null)
            {
                return NotFound($"UserTask with ID {id} not found.");
            }
            return Ok(userTask);
        }

        // POST: api/UserTask
        [HttpPost]
        [Route("api/create")]
        public async Task<IActionResult> CreateUserTask([FromBody] UsersTaskDto userTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTask = new TfaUsersTask
            {
                UserId = userTaskDto.UserId,
                UserTaskId = userTaskDto.TaskId,
                StatusTask = userTaskDto.StatusTask,
                EvidencePath = userTaskDto.EvidencePath,
                EvidenceUploadDate = userTaskDto.EvidenceUploadDate
            };

            await _userTaskService.AddAsync(userTask);

            return CreatedAtAction(nameof(GetUserTaskById), new { id = userTask.UserTaskId }, userTask);
        }

        // PUT: api/UserTask/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserTask(int id, [FromBody] UsersTaskDto userTaskDto)
        {
            var existingUserTask = await _userTaskService.GetByIdAsync(id);
            if (existingUserTask == null)
            {
                return NotFound($"UserTask with ID {id} not found.");
            }

            existingUserTask.UserId = userTaskDto.UserId;
            existingUserTask.UserTaskId = userTaskDto.TaskId;
            existingUserTask.StatusTask = userTaskDto.StatusTask;
            existingUserTask.EvidencePath = userTaskDto.EvidencePath;
            existingUserTask.EvidenceUploadDate = userTaskDto.EvidenceUploadDate;

            await _userTaskService.UpdateAsync(existingUserTask);
            return NoContent();
        }

        // DELETE: api/UserTask/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTask(int id)
        {
            var userTask = await _userTaskService.GetByIdAsync(id);
            if (userTask == null)
            {
                return NotFound($"UserTask with ID {id} not found.");
            }

            await _userTaskService.DeleteAsync(id);
            return NoContent();
        }
    }
}
