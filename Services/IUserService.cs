using FinanceAPI.DTOs;
using static FinanceAPI.DTOs.UserDtos;

namespace FinanceAPI.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterAsync(RegisterUserDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}