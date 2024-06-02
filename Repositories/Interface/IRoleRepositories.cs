using BbCenter.Models;

namespace BbCenter.Repositories.Interface
{
    public interface IRoleRepositories
    {
        void CreateRole(Role role);
        Role GetRoleByName(string name);
        Role GetRoleById(Guid id);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        List<Role> GetRoles();
    }
}
