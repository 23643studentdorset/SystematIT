using AutoMapper;
using DataModel;
using KanbanModule.DTOs;

namespace WebApi.Profiles
{
    public class KanbanTaskCommentProfile: Profile
    {
        public KanbanTaskCommentProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
