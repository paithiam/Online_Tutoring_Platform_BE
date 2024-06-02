using BbCenter.Dto.User;
using BbCenter.Models;

namespace BbCenter.Repositories.Interface
{
    public interface IUserRepositories
    {
        void CreateUser(User user);
        User GetUserByEmail(string email);
        User GetUserById(Guid id);
        void UpdateUser(User user);
        void DeleteUser(User user);
        List<User> GetAllUser();
        List<User> GetAllUserByRoleIdAndBranchId(QueryDto queryDto);
        /*        List<User> GetAllUserByRole(string role);
                List<User> GetAllTeacherByRoleAndSubject(string role, Guid subjectId);
                List<User> GetAllUserByCenter(Guid centerId);*/
    }
}
