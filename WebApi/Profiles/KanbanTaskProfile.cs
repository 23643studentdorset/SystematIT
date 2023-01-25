using AutoMapper;
using DataModel;
using KanbanModule.DTOs;

namespace WebApi.Profiles
{
    public class KanbanTaskProfile : Profile
    {
        public KanbanTaskProfile()
        {
            CreateMap<KanbanTaskHistory, KanbanTaskDetailsDto>()
                .ForMember(dest => dest.KanbanTaskId, opt => opt.MapFrom(src => src.KanbanTaskId))
                .ForMember(dest => dest.Reporter, opt => opt.MapFrom(src => src.KanbanTask.Reporter))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.KanbanTask.CreatedOn))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.TaskStatus, opt => opt.MapFrom(src => src.TaskStatus))
                .ForMember(dest => dest.Assignee, opt => opt.MapFrom(src => src.Assignee))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store))
                .ForMember(dest => dest.LastModifiedOn, opt => opt.MapFrom(src => src.LastModifiedOn))
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.LastModifiedBy))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.KanbanTask.Comments));

            CreateMap<KanbanTask, KanbanTaskDto>();
        }
    }
}
