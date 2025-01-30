//using TaskManager.Models;
//using TaskManager.Repositories;

//namespace TaskManager.Services
//{
//    public class UserTaskService : ITaskUserService
//    {
//        private readonly ITaskUserRepository _repository;

//        public UserTaskService(ITaskUserRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<IEnumerable<TfaUsersTask>> GetAllAsync()
//        {
//            return await _repository.GetAllAsync();
//        }

//        public async Task<TfaUsersTask?> GetByIdAsync(int id)
//        {
//            return await _repository.GetByIdAsync(id);
//        }

//        public async Task AddAsync(TfaUsersTask entity)
//        {
//            await _repository.AddAsync(entity);
//        }

//        public async Task UpdateAsync(TfaUsersTask entity)
//        {
//            await _repository.UpdateAsync(entity);
//        }

//        public async Task DeleteAsync(int id)
//        {
//            await _repository.DeleteAsync(id);
//        }

//        public async Task<IEnumerable<TfaUsersTask>> GetTasksByUserIdAsync(int userId)
//        {
//            return await _repository.GetTasksByUserIdAsync(userId);
//        }
//    }
//}

