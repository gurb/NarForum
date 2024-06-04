using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.Permission;
using Application.Models.Identity.Role;
using Identity.Services;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("ResetPermissions")]
        public async Task<ApiResponse> ResetPermissions()
        {
            return await _permissionService.ResetPermissions();
        }

        [HttpPost("SetPermission")]
        public async Task<ApiResponse> SetPermission(SetPermissionRequest request)
        {
            return await _permissionService.SetPermission(request);
        }

        [HttpGet("GetPermissions")]
        public async Task<GetPermissionsResponse> GetPermissions()
        {
            return await _permissionService.GetPermissions();
        }

        [HttpPost("AddPermissionDefinition")]
        public async Task<ApiResponse> AddPermissionDefinition(AddPermissionDefinitionRequest request)
        {
            return await _permissionService.AddPermissionDefinition(request);
        }

        [HttpPost("DeletePermissionDefinition")]
        public async Task<ApiResponse> DeletePermissionDefinition(DeletePermissionDefinitionRequest request)
        {
            return await _permissionService.DeletePermissionDefinition(request);
        }

        [HttpPost("UpdatePermissionDefinition")]
        public async Task<ApiResponse> UpdatePermissionDefinition(UpdatePermissionDefinitionRequest request)
        {
            return await _permissionService.UpdatePermissionDefinition(request);
        }

        [HttpGet("GetPermissionDefinitions")]
        public async Task<GetPermissionDefinitionsResponse> GetPermissionDefinitions()
        {
            return await _permissionService.GetPermissionDefinitions();
        }
    }
}
