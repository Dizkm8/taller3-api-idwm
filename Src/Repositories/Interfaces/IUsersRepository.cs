using Backend.Src.Models;

namespace Backend.Src.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public Task<User?> GetById(int id);

        public Task<User?> GetByUsername(string username);

        public Task<List<User>> GetAll();

        public Task<User> Add(User user);
    }
}