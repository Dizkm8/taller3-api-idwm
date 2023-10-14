using Backend.Src.DTO.Users;
using Backend.Src.Models;

namespace Backend.Src.Services.Interfaces
{
    public interface IMapperService
    {
        public List<UserDto> MapUsers(List<User> users);
    }
}