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

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDto>> Register(RegisterClientDto registerClientDto)
        {
            var token = await _authService.RegisterClient(registerClientDto);
            return new LoginResponseDto()
            {
                Token = token
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginUserDto loginUserDto)
        {
            var jwt = await _authService.Login(loginUserDto);

            if (jwt is null) return BadRequest("Invalid Credentials");

            return new LoginResponseDto()
            {
                Token = jwt
            };
        }
    }
}