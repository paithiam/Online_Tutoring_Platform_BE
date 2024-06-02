using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BbCenter.Dto.User;
using BbCenter.Services.Interface;

namespace BbCenter.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            try
            {
                List<RoleDto> roles = _roleService.GetRoles();
                return Ok(roles);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting roles");
            }
        }
    }
}
