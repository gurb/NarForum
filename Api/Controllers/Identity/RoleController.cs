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

        /// <summary>
        /// Adds new user role
        /// </summary>
        /// <param name="request">The request containing Name(string) and NormalizedName(string) as fields</param>
        /// <returns>The adding new user role result as ApiResponse</returns>
        [HttpPost("AddUserRole")]
        public async Task<ApiResponse> AddUserRole(AddRoleRequest request)
        {
            return await _roleService.AddRole(request);
        }

        /// <summary>
        /// Updates the user role
        /// </summary>
        /// <param name="request">The request containing Id(string), Name(string) and NormalizedName(string) as fields</param>
        /// <returns>The updating the user role result as ApiResponse</returns>
        [HttpPost("UpdateUserRole")]
        public async Task<ApiResponse> UpdateUserRole(UpdateRoleRequest request)
        {
            return await _roleService.UpdateRole(request);
        }

        /// <summary>
        /// Removes the user role
        /// </summary>
        /// <param name="request">The request containing User Role Id(string)</param>
        /// <returns>The removing the user role result as ApiResponse</returns>
        [HttpPost("RemoveUserRole")]
        public async Task<ApiResponse> RemoveUserRole(RemoveRoleRequest request)
        {
            return await _roleService.RemoveRole(request);
        }

        /// <summary>
        /// Get all user roles
        /// </summary>
        /// <returns>The list of UserRoleResponse result as GetUserRolesResponse</returns>
        [HttpGet("GetUserRoles")]
        public async Task<GetUserRolesResponse> GetUserRoles()
        {
            return await _roleService.GetRoles();
        }
    }
}
