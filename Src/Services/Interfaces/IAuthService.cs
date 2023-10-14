using Backend.Src.DTO;

namespace Backend.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<string> RegisterClient(RegisterClientDto registerClientDto);

        public Task<string?> Login(LoginUserDto loginUserDto);
    }
}