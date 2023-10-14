using Backend.Src.DTO.Users;
using Backend.Src.Models;
using Backend.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> AllUsers()
        {
            var users = await _usersService.GetAll();
            return users;
        }
    }
}