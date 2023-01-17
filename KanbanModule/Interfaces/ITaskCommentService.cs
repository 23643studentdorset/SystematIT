using DataModel;
using KanbanModule.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanModule.Interfaces
{
    public interface ITaskCommentService
    {
        Task<IEnumerable<Comment>> GetAllByTaskId(int taskId);

        Task<int> AddComment(AddCommentRequest request);
        
        Task<bool> DeleteComment(int taskId, int commentId);
    }
}
