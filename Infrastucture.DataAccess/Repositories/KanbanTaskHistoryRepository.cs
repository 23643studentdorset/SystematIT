using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.DataAccess.Repositories
{
    public class KanbanTaskHistoryRepository : GenericRepository<KanbanTaskHistory>, IKanbanTaskHistoryRepository
    {
        private readonly DbSet<KanbanTaskHistory> _entities;

        public KanbanTaskHistoryRepository(ApplicationDbContext context) : base(context)
        {
            _entities = context.Set<KanbanTaskHistory>();
        }

        public async Task<IEnumerable<KanbanTaskHistory>> FilterByUser(int companyId, int userId, int statusId)
        {

            return await _entities.Where(x =>
                    x.KanbanTask.CompanyId == companyId
                    && x.KanbanTask.CurrentVersionId == x.VersionId
                    && x.TaskStatusStatusId == statusId
                    && (x.KanbanTask.ReporterUserId == userId || x.AssigneeUserId == userId)).ToListAsync();
        }

        public async Task<IEnumerable<KanbanTaskHistory>> FilterByDepartment(int companyId, int departmentId, int statusId)
        {

            return await _entities.Where(x =>
                    x.KanbanTask.CompanyId == companyId
                    && x.KanbanTask.CurrentVersionId == x.VersionId
                    && x.TaskStatusStatusId == statusId
                    && x.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<KanbanTaskHistory> GetKanbanTaskDetails(int taskId, int versionId)
        {

            return await _entities.Include(y => y.KanbanTask.Comments).FirstOrDefaultAsync(x =>
                    x.KanbanTaskId == taskId
                    && x.VersionId == versionId);
        }
    }
}
