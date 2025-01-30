//using Microsoft.EntityFrameworkCore;
//using TaskManager.Data;
//using TaskManager.Models;

//namespace TaskManager.Repositories
//{
//    public class TaskUserRepository : ITaskUserRepository
//    {
//        private readonly DbAb0bdeTalentseedsContext _context;

//        public TaskUserRepository(DbAb0bdeTalentseedsContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<TfaUsersTask>> GetAllAsync()
//        {
//            return await _context.TfaUsersTasks
//                .Include(ut => ut.User)
//                .Include(ut => ut.UserTask)
//                .ToListAsync();
//        }

//        public async Task<TfaUsersTask?> GetByIdAsync(int id)
//        {
//            return await _context.TfaUsersTasks
//                .Include(ut => ut.User)
//                .Include(ut => ut.UserTask)
//                .FirstOrDefaultAsync(ut => ut.UserTaskId == id);
//        }

//        public async Task AddAsync(TfaUsersTask entity)
//        {
//            await _context.TfaUsersTasks.AddAsync(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(TfaUsersTask entity)
//        {
//            _context.TfaUsersTasks.Update(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var entity = await GetByIdAsync(id);
//            if (entity != null)
//            {
//                _context.TfaUsersTasks.Remove(entity);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<IEnumerable<TfaUsersTask>> GetTasksByUserIdAsync(int userId)
//        {
//            return await _context.TfaUsersTasks
//                .Where(ut => ut.UserId == userId)
//                .Include(ut => ut.User)
//                .Include(ut => ut.UserTask)
//                .ToListAsync();
//        }

//    }
//}
