using Backend.Src.DTO.Users;
using Backend.Src.Repositories.Interfaces;
using Backend.Src.Services.Interfaces;

namespace Backend.Src.Services
{
    public class UsersService : IUsersService
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IMapperService _mapperService;

        public UsersService(IUsersRepository usersRepository, IMapperService mapperService)
        {
            _usersRepository = usersRepository;
            _mapperService = mapperService;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _usersRepository.GetAll();

            var mappedUsers = _mapperService.MapUsers(users);

            return mappedUsers;
        }
    }
}