using BbCenter.Dto.User;

namespace BbCenter.Services.Interface
{
    public interface IUserService
    {
        UserDto GetUserById(Guid userId);
        UserDto UpdateUser(Guid id, UpdateUserDto updateUserDto);
        string DeleteUser(Guid userId);
        UserDto CreateUser(CreateUserDto userDto);
        List<UserDto> GetAllUser();
        List<UserDto> GetAllUserByRoleIdAndBranchId(QueryDto queryDto);
    }
}
