using Backend.Src.DTO.Users;
using Backend.Src.Repositories.Interfaces;
using Backend.Src.Services.Interfaces;

namespace Backend.Src.Services
{
    public class UsersService : IUsersService
    {

        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _usersRepository.GetAll();

            var mappedUsers = users.Select(u => new UserDto(){
                Id = u.Id,
                Username = u.Username,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password,
                Role = new RoleDto(){
                    Id = u.Role.Id,
                    Name = u.Role.Name
                }
            }).ToList();

            return mappedUsers;
        }
    }
}