//using Microsoft.EntityFrameworkCore;
//using TaskManager.Data;
//using TaskManager.DTOs;
//using TaskManager.Models;

//namespace TaskManager.Repositories
//{
//    public class TaskRepository : ITaskRepository
//    {
//        private readonly DbAb0bdeTalentseedsContext _context;

//        public TaskRepository(DbAb0bdeTalentseedsContext context)
//        {
//            _context = context;
//        }
//        public async Task<IEnumerable<TfaTask>> GetAllAsync()
//        {
//            return await _context.TfaTasks.ToListAsync();
//        }

//        public async Task<TfaTask?> GetByIdAsync(int id)
//        {
//            return await _context.TfaTasks
//                .Include(t => t.Category)
//                .FirstOrDefaultAsync(t => t.TaskId == id);
//        }

//        public async Task AddAsync(TfaTask entity)
//        {
//            await _context.TfaTasks.AddAsync(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(TfaTask entity)
//        {
//            _context.TfaTasks.Update(entity);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var entity = await GetByIdAsync(id);
//            if (entity != null)
//            {
//                _context.TfaTasks.Remove(entity);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<IEnumerable<TfaTask>> GetTasksByCategoryIdAsync(int categoryId)
//        {
//            return await _context.TfaTasks
//                .Where(t => t.CategoryId == categoryId)
//                .Include(t => t.Category)
//                .ToListAsync();
//        }

//        public async Task<IEnumerable<int>> GetUserIdsByCategoryIdAsync(int categoryId)
//        {
//            var teamIds = await _context.TfaTeamsCategories
//                .Where(ctc => ctc.CategoriesId == categoryId) // Filtra por categoría
//                .Select(ctc => ctc.TeamId) // Obtén solo los IDs de los equipos
//                .Distinct() // Evita duplicados
//                .ToListAsync();

//            var collaboratorIds = await _context.TfaTeamsCollaborators
//                .Where(tc => teamIds.Contains(tc.ColaboratorTeamID)) // Filtra por los TeamId obtenidos
//                .Select(tc => tc.ColaboratorUsersID) // Obtén los IDs de los colaboradores
//                .Distinct() // Evita duplicados
//                .ToListAsync();

//            return collaboratorIds;

//        }

//        public async Task AddAsyncTaskUser(IEnumerable<TfaUsersTask> entity)
//        {
//            await _context.TfaUsersTasks.AddRangeAsync(entity);
//            await _context.SaveChangesAsync();
//        }


//    }
//}

