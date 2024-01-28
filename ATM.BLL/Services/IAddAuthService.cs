using ATM.BLL.DTOs.LoginDto;
using ATM.BLL.DTOs.RegisterDtos;

namespace ATM.BLL.Services
{
    public interface IAddAuthService
    {
        Task<bool> RegisterUser(RegisterDto registerDto);
        Task<bool> Login(LoginDto credentials);

        string GenerateToken(LoginDto credentials);

    }
}