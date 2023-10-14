using AutoMapper;
using Backend.Src.DTO.Users;
using Backend.Src.Models;
using Backend.Src.Services.Interfaces;

namespace Backend.Src.Services
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<UserDto> MapUsers(List<User> users)
        {
            var mappedUsers = users.Select(u => _mapper.Map<UserDto>(u)).ToList();
            return mappedUsers;
        }
    }
}