using KanbanModule.DTOs;


namespace KanbanModule.Interfaces
{
    public interface ITaskCommentService
    {
        Task<IEnumerable<CommentDto>> GetAllByTaskId(int taskId);

        Task<int> AddComment(AddCommentRequest request);

        Task<bool> DeleteComment(int commentId);
    }
}
