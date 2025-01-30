using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskUserService
    {
        Task<bool> AssignTaskToUserAsync(int taskId);

        Task<bool> DeleteTaskAsync(int taskId);

    }
}
