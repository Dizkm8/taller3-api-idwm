using Backend.Src.DTO.Users;

namespace Backend.Src.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<UserDto>> GetAll();
    }
}