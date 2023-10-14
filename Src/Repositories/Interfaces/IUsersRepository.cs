using Backend.Src.Models;

namespace Backend.Src.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public Task<User> GetById();

        public Task<User> GetByEmail();

        public Task<User> GetByUsername();

        public Task<List<User>> GetAll();
    }
}