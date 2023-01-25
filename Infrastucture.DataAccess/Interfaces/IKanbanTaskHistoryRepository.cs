using DataModel;

namespace Infrastucture.DataAccess.Interfaces
{
    public interface IKanbanTaskHistoryRepository : IGenericRepository<KanbanTaskHistory>
    {
        //Task<TaskHistory> GetLastHistory(int taskId);
    }
}
