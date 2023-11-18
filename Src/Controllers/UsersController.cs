using Backend.Src.Data;
using Backend.Src.DTO.Users;
using Backend.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly DataContext _context;
        public UsersController(IUsersService usersService, DataContext dataContext)
        {
            _usersService = usersService;
            _context = dataContext;

        }

        // [HttpGet]
        // [Authorize]
        // public async Task<ActionResult<List<UserDto>>> AllUsers()
        // {
        //     var users = await _usersService.GetAll();
        //     return users;
        // }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<UserDto>>> AllUsers()
        {
            var users = await _context.Users
                                    .Include(u => u.Role)
                                    .ToListAsync();

            var mappedUsers = users.Select(u => new UserDto(){
                Id = u.Id,
                Username = u.Username,
                RoleId = u.RoleId,
                Role = u.Role
            }).ToList();

            return mappedUsers;
        }
    }
}