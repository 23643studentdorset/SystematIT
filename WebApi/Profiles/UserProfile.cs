using AutoMapper;
using DataModel;
using Infrastucture.Identity.DTOs;

namespace WebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserRequest, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.Dob))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.Company, opt => opt.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.userRoles, opt => opt.MapFrom(src => src.UserRoles));
        }
        
    }
}
