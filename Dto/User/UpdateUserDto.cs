using BbCenter.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.User
{
    public class UpdateUserDto : CreateUserDto
    {
        public Guid UserId { get; set; }
    }
}
