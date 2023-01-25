using AutoMapper;
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
        private readonly IMapper _mapper;

        public TaskCommentService (ICommentRepository commentRepository, IKanbanTaskRepository kanbanTaskRepository, ICurrentUser currentUser, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _kanbanTaskRepository = kanbanTaskRepository;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<int> AddComment(AddCommentRequest request)
        {
            var kanbanTask = await _kanbanTaskRepository.Get(request.TaskId);
            if (kanbanTask == null || kanbanTask.CompanyId != _currentUser.CompanyId)
                throw new Exception("Task does not exists in the system");

            var comment = new Comment() { Description = request.Comment, KanbanTask = kanbanTask };

            await _commentRepository.Insert(comment);
            return comment.CommentId;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var comment = await _commentRepository.GetWithTaskDetails(commentId);
            if (comment == null || comment.KanbanTask.CompanyId != _currentUser.CompanyId)
                throw new Exception("Comment does not exists in the system");

            await _commentRepository.Delete(comment);
            return true;
        }



        public async Task<IEnumerable<CommentDto>> GetAllByTaskId(int taskId)
        {
            try
            {
                var kanbanTask = await _kanbanTaskRepository.Get(taskId);
                if (kanbanTask == null || kanbanTask.CompanyId != _currentUser.CompanyId)
                    throw new Exception("Task does not exists in the system");

                var result = await _commentRepository.FindListByCondition(x => x.KanbanTaskId == taskId);

                var commentMapper = _mapper.Map<IEnumerable<CommentDto>>(result);
                return commentMapper;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
