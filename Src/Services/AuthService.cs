using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Src.DTO;
using Backend.Src.Models;
using Backend.Src.Repositories.Interfaces;
using Backend.Src.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Src.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapperService _mapperService;

        public AuthService(IUsersRepository usersRepository, IConfiguration configuration,
                            IMapperService mapperService)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _mapperService = mapperService;
        }

        public async Task<string?> Login(LoginUserDto loginUserDto)
        {
            var user = await _usersRepository.GetByUsername(loginUserDto.Username);
            if (user is null) return null;

            var result = BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password);
            if (!result) return null;

            var token = CreateToken(user);
            return token;
        }

        public async Task<string> RegisterClient(RegisterClientDto registerClientDto)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerClientDto.Password, salt);

            var mappedUser = _mapperService.RegisterClientDtoToUser(registerClientDto);
            // Ensure fill fields not mapped
            mappedUser.Password = passwordHash;
            mappedUser.RoleId = 1; //TODO: Avoid hardcoded role

            var user = await _usersRepository.Add(mappedUser);
            var token = CreateToken(user);
            return token;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>{
                new (ClaimTypes.Email, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}