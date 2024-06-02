using BbCenter.Dto.Auth;
namespace BbCenter.Services.Interface
{
    public interface IAuthService
    {
        string Register(RegisterDto registerDto);
        AuthResponse Login(LoginDto loginDto);
    }
}
