using AutoMapper;
using Backend.Src.DTO;
using Backend.Src.DTO.Users;
using Backend.Src.Models;

namespace Backend.Src.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<RegisterClientDto, User>();
        }
    }
}