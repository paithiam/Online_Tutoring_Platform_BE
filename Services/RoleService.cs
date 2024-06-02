using AutoMapper;
using BbCenter.Dto.User;
using BbCenter.Models;
using BbCenter.Repositories.Interface;
using BbCenter.Services.Interface;

namespace BbCenter.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepositories _roleRepository;

        public RoleService(IMapper mapper, IRoleRepositories roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public void CreateRole(RoleDto role)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(RoleDto role)
        {
            throw new NotImplementedException();
        }

        public RoleDto GetRoleById(Guid id)
        {
            throw new NotImplementedException();
        }

        public RoleDto GetRoleByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<RoleDto> GetRoles()
        {
            List<Role> roles = _roleRepository.GetRoles();
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public void UpdateRole(RoleDto role)
        {
            throw new NotImplementedException();
        }
    }
}
