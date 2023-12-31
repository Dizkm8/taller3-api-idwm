using Backend.Src.Data;
using Backend.Src.Models;
using Backend.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Src.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            var createdUser = (await _context.Users.AddAsync(user)).Entity;
            await _context.SaveChangesAsync();
            return createdUser;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users
                                    .Include(user => user.Role)
                                    .ToListAsync();
            return users;
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User?> GetByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }
    }
}