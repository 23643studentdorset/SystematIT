using DataModel;

namespace Infrastucture.DataAccess.Interfaces
{
    public interface IKanbanTaskHistoryRepository : IGenericRepository<KanbanTaskHistory>
    {
        Task<IEnumerable<KanbanTaskHistory>> FilterByUser(int companyId, int userId, int statusId);

        Task<IEnumerable<KanbanTaskHistory>> FilterByDepartment(int companyId, int departmentId, int statusId);

        Task<KanbanTaskHistory> GetKanbanTaskDetails(int taskId, int versionId);
    }
}
