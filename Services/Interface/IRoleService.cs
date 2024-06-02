using BbCenter.Dto.User;
using BbCenter.Models;

namespace BbCenter.Services.Interface
{
    public interface IRoleService
    {
        void CreateRole(RoleDto role);
        RoleDto GetRoleByName(string name);
        RoleDto GetRoleById(Guid id);
        void UpdateRole(RoleDto role);
        void DeleteRole(RoleDto role);
        List<RoleDto> GetRoles();
    }
}
