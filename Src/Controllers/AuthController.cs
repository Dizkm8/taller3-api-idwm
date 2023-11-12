using Backend.Src.DTO;
using Backend.Src.Data;
using Microsoft.AspNetCore.Mvc;
using Backend.Src.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

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

        // [HttpPost("register")]
        // public async Task<ActionResult<LoginResponseDto>> Register(RegisterClientDto registerClientDto)
        // {
        //     var response = await _authService.RegisterClient(registerClientDto);
        //     return Ok(response);
        // }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginUserDto loginUserDto)
        {
            var response = await _authService.Login(loginUserDto);

            if (response is null) return BadRequest("Invalid Credentials");
            ; return Ok(response);
        }
    }
}