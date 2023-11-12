using Backend.Src.DTO;

namespace Backend.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> RegisterClient(RegisterClientDto registerClientDto);

        public Task<LoginResponseDto?> Login(LoginUserDto loginUserDto);
    }
}