using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.Permission;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// Resets permissions as default
        /// </summary>
        /// <returns>The resetting permissions result</returns>
        [HttpPost("ResetPermissions")]
        public async Task<ApiResponse> ResetPermissions()
        {
            return await _permissionService.ResetPermissions();
        }

        /// <summary>
        /// Refreshes permissions for defined new permission definition
        /// </summary>
        /// <returns>The refreshing permissions response</returns>
        [HttpPost("RefreshPermissions")]
        public async Task<ApiResponse> RefreshPermissions()
        {
            return await _permissionService.RefreshPermissions();
        }

        /// <summary>
        /// Sets the existed permission value as true or false 
        /// </summary>
        /// <param name="request">The request containing Permission Id(string) and Value(bool) fields</param>
        /// <returns>The setting permission result as ApiResponse</returns>
        [HttpPost("SetPermission")]
        public async Task<ApiResponse> SetPermission(SetPermissionRequest request)
        {
            return await _permissionService.SetPermission(request);
        }

        /// <summary>
        /// Gets all permissions
        /// </summary>
        /// <returns>The list of PermissionDTO in GetPermissionsResponse</returns>
        [HttpGet("GetPermissions")]
        public async Task<GetPermissionsResponse> GetPermissions()
        {
            return await _permissionService.GetPermissions();
        }

        /// <summary>
        /// Gets permissions related the specific role
        /// </summary>
        /// <param name="roleId">Role Id as string</param>
        /// <returns>The list of PermissionDTO in GetPermissionsResponse</returns>
        [HttpGet("GetPermissionsByRoleId")]
        public async Task<GetPermissionsResponse> GetPermissions(string roleId)
        {
            return await _permissionService.GetPermissions(roleId);
        }

        /// <summary>
        /// Adds permission definition
        /// </summary>
        /// <param name="request">The request containing Name(string), DisplayName(string) and ParentPermissionDefinitionId(string)</param>
        /// <returns>The adding permission definition result as ApiResponse</returns>
        [HttpPost("AddPermissionDefinition")]
        public async Task<ApiResponse> AddPermissionDefinition(AddPermissionDefinitionRequest request)
        {
            return await _permissionService.AddPermissionDefinition(request);
        }

        /// <summary>
        /// Changes permission status
        /// </summary>
        /// <param name="permissionId">Permission Id as string</param>
        /// <returns>The changing permission's status result as ApiResponse</returns>
        [HttpPost("ChangePermissionStatus")]
        public async Task<ApiResponse> ChangePermissionStatus(string permissionId)
        {
            return await _permissionService.ChangePermissionStatus(permissionId);
        }

        /// <summary>
        /// Deletes the selected permission definition
        /// </summary>
        /// <param name="request">The request containing PermissionDefinitionId(string)</param>
        /// <returns>The deleting the permission definition result as ApiResponse</returns>
        [HttpPost("DeletePermissionDefinition")]
        public async Task<ApiResponse> DeletePermissionDefinition(DeletePermissionDefinitionRequest request)
        {
            return await _permissionService.DeletePermissionDefinition(request);
        }

        /// <summary>
        /// Updates the selected permission definition
        /// </summary>
        /// <param name="request">The request containing PermissionDefinitionId(string)</param>
        /// <returns>The updating the permission definition result as ApiResponse</returns>
        [HttpPost("UpdatePermissionDefinition")]
        public async Task<ApiResponse> UpdatePermissionDefinition(UpdatePermissionDefinitionRequest request)
        {
            return await _permissionService.UpdatePermissionDefinition(request);
        }

        /// <summary>
        /// Gets all permissions definitions
        /// </summary>
        /// <returns>The list of PermissionDefinitionDTO in GetPermissionDefinitionsResponse</returns>
        [HttpGet("GetPermissionDefinitions")]
        public async Task<GetPermissionDefinitionsResponse> GetPermissionDefinitions()
        {
            return await _permissionService.GetPermissionDefinitions();
        }
    }
}
