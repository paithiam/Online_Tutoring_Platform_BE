using BbCenter.Dto.Center;
using BbCenter.Dto.Subject;

namespace BbCenter.Dto.User
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Degree { get; set; }
        public RoleDto? Role { get; set; }
        public CenterDto? Center { get; set; }
        public SubjectDto? Subject { get; set; }
    }
}
