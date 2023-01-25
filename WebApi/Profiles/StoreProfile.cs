using AutoMapper;
using DataModel;
using KanbanModule.DTOs;

namespace WebApi.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<AddStoreRequest, Store>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Company, opt => opt.Ignore())
                .AfterMap((src, dest) =>{ dest.CreatedOn = DateTime.UtcNow; })
                .AfterMap((src, dest) =>{ dest.Active = true; });

            CreateMap<Store, StoreDto>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy));
        }
    }
}
