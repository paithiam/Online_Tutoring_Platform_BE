using BbCenter.Constraints;
using BbCenter.Dto.User;

namespace BbCenter.Dto.Auth
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string Role { get; set; }
        public UserDto User { get; set; }
    }
}
