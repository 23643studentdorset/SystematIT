using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.DataAccess.Repositories
{
    public class TaskHistoryRepository: GenericRepository<TaskHistory>, ITaskHistoryRepository
    {
        private readonly DbSet<TaskHistory> _entities;
        public TaskHistoryRepository(ApplicationDbContext context) : base (context)
        {
            _entities = context.Set<TaskHistory>();
        }

        public async Task<TaskHistory> GetLastHistory(int taskId)
        {
            return await _entities.LastAsync(x => x.KanbanTaskId == taskId);
        }
    }
}
