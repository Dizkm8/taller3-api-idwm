using Backend.Src.DTO;
using Backend.Src.Data;
using Backend.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Src.Services.Interfaces;

namespace Backend.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public AuthController(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }


        // La ruta es localhost:5267/api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterClientDto registerClientDto)
        {
            var token = await _authService.RegisterClient(registerClientDto);
            return token;
        }

        // La ruta es localhost:5267/api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserDto loginUserDto)
        {
            var jwt = await _authService.Login(loginUserDto);

            if(jwt is null) return BadRequest("Invalid Credentials");

            return jwt;
        }
    }
}