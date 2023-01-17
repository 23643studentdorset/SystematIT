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
        Task <KanbanTask>GetById(int taskId);
        Task<IEnumerable<KanbanTask>> GetAllByUserId(int userId);
        Task<IEnumerable<KanbanTask>> GetAllByCompanyId(int CompanyId);
        Task<IEnumerable<KanbanTask>> GetAllByDepartmentId(int departmentId);
        Task<int> AddKanbanTask(AddKanbanTaskRequest request);
        Task<bool> UpdateKanbanTask(UpdateKanbanTask request);
    }
}
