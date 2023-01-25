using DataModel;
using KanbanModule.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.Interfaces
{
    public interface IKanbanTaskService
    {
        Task<KanbanTaskDto>GetById(int taskId);

        Task<KanbanTaskDetailsDto> GetTaskDetailsById(int taskId);

        Task<IEnumerable<KanbanTaskDetailsDto>> GetAllByUserId(int userId);

        Task<IEnumerable<KanbanTaskDetailsDto>> GetAllTasks();

        Task<IEnumerable<KanbanTaskDetailsDto>> GetAllByDepartmentId(int departmentId);

        Task<int> AddKanbanTask(AddKanbanTaskRequest request);

        Task<bool> UpdateKanbanTask(UpdateKanbanTask request);
    }
}
