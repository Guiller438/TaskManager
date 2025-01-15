using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TfaTask>> GetAllAsync();
        Task<TfaTask?> GetByIdAsync(int id);
        Task AddAsync(TfaTask entity);
        Task UpdateAsync(TfaTask entity);
        Task DeleteAsync(int id);

        // Método personalizado
        Task<IEnumerable<TfaTask>> GetTasksByCategoryIdAsync(int categoryId);   
    }
}
