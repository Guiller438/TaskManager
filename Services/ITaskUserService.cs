using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskUserService
    {
        Task<IEnumerable<TfaUsersTask>> GetAllAsync();
        Task<TfaUsersTask?> GetByIdAsync(int id);
        Task AddAsync(TfaUsersTask entity);
        Task UpdateAsync(TfaUsersTask entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TfaUsersTask>> GetTasksByUserIdAsync(int userId);
    }
}
