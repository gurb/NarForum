using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService) 
        {
            _roleService = roleService;
        }

        [HttpPost("AddUserRole")]
        public async Task<ApiResponse> AddUserRole(AddRoleRequest request)
        {
            return await _roleService.AddRole(request);
        }

        [HttpPost("UpdateUserRole")]
        public async Task<ApiResponse> UpdateUserRole(UpdateRoleRequest request)
        {
            return await _roleService.UpdateRole(request);
        }

        [HttpPost("RemoveUserRole")]
        public async Task<ApiResponse> RemoveUserRole(RemoveRoleRequest request)
        {
            return await _roleService.RemoveRole(request);
        }

        [HttpGet("GetUserRoles")]
        public async Task<GetUserRolesResponse> GetUserRoles()
        {
            return await _roleService.GetRoles();
        }
    }
}
