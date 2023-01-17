using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Identity.Interfaces;
using KanbanModule.DTOs;
using KanbanModule.Interfaces;

namespace KanbanModule.Services
{
    public class TaskCommentService : ITaskCommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IKanbanTaskRepository _kanbanTaskRepository;
        private readonly ICurrentUser _currentUser; 

        public TaskCommentService (ICommentRepository commentRepository, IKanbanTaskRepository kanbanTaskRepository, ICurrentUser currentUser)
        {
            _commentRepository = commentRepository;
            _kanbanTaskRepository = kanbanTaskRepository;
            _currentUser = currentUser;
        }

        public async Task<int> AddComment(AddCommentRequest request)
        {
            var kanbanTask = await _kanbanTaskRepository.FindByCondition(x => x.KanbanTaskId == request.TaskId && x.CompanyId == _currentUser.CompanyId);
            if (kanbanTask == null) throw new Exception("Task does not exists in the system");

            var comment = new Comment() { Description = request.Comment, KanbanTask = kanbanTask };

            await _commentRepository.Insert(comment);
            return comment.CommentId;
        }

        public async Task<bool> DeleteComment(int taskId, int commentId)
        {
            var kanbantask = await _kanbanTaskRepository.FindByCondition(x => x.KanbanTaskId == taskId && x.CompanyId == _currentUser.CompanyId);
            if (kanbantask == null) throw new Exception("Task does not exists in the system");

            var comment = await _commentRepository.FindByCondition(x => x.CommentId == commentId);
            if (comment == null) throw new Exception("Comment does not exist in the system");

            await _commentRepository.Delete(comment);
            return true;
        }

        public async Task<IEnumerable<Comment>> GetAllByTaskId(int taskId)
        {
            try
            {
                var result = await _commentRepository.FindListByCondition(x => x.KanbanTaskId == taskId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
