using DataModel;

namespace Infrastucture.DataAccess.Interfaces
{
    public interface ITaskHistoryRepository : IGenericRepository<TaskHistory>
    {
        Task<TaskHistory> GetLastHistory(int taskId);
    }
}
