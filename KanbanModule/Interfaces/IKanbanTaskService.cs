using KanbanModule.DTOs;

namespace KanbanModule.Interfaces
{
    public interface IKanbanTaskService
    {
        Task<KanbanTaskDto> GetById(int taskId);

        Task<KanbanTaskDetailsDto> GetTaskDetailsById(int taskId);

        Task<IEnumerable<KanbanTaskHistoryFilteredDto>> GetAllByUserId(int userId, string status);

        Task<IEnumerable<KanbanTaskDetailsDto>> GetAllTasks();

        Task<IEnumerable<KanbanTaskHistoryFilteredDto>> GetAllByDepartmentId(int departmentId, string status);

        Task<int> AddKanbanTask(AddKanbanTaskRequest request);

        Task<bool> UpdateKanbanTask(UpdateKanbanTask request);
    }
}
