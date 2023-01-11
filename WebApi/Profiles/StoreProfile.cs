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
                .AfterMap((_, dest) =>
                {
                    dest.CreatedOn = DateTime.UtcNow;
                })
                .AfterMap((_, dest) =>
                {
                    dest.Active = true;
                });

            CreateMap<Store, StoreDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.CreatedByUserId, opt => opt.MapFrom(src => src.CreatedBy.UserId))
                .ForMember(dest => dest.CreatedByFirstName, opt => opt.MapFrom(src => src.CreatedBy.FirstName))
                .ForMember(dest => dest.CreatedByLastName, opt => opt.MapFrom(src => src.CreatedBy.LastName))
                .ForMember(dest => dest.ModifiedByUserId, opt => opt.MapFrom(src => src.ModifiedBy.UserId))
                .ForMember(dest => dest.ModifiedByFirstName, opt => opt.MapFrom(src => src.ModifiedBy.FirstName))
                .ForMember(dest => dest.ModifiedByLastName, opt => opt.MapFrom(src => src.ModifiedBy.LastName));
        }
    }
}
