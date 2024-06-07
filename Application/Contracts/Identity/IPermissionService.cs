using Application.Models;
using Application.Models.Identity.Permission;
using Application.Models.Identity.Role;

namespace Application.Contracts.Identity
{
    public interface IPermissionService
    {
        Task<ApiResponse> RefreshPermissions();
        Task<ApiResponse> ResetPermissions();
        Task<ApiResponse> SetPermission(SetPermissionRequest request);
        Task<ApiResponse> ChangePermissionStatus(string permissionId);
        Task<GetPermissionDefinitionsResponse> GetPermissionDefinitions();
        Task<GetPermissionsResponse> GetPermissions();
        Task<GetPermissionsResponse> GetPermissions(string roleId);
        Task<ApiResponse> AddPermissionDefinition(AddPermissionDefinitionRequest request);
        Task<ApiResponse> UpdatePermissionDefinition(UpdatePermissionDefinitionRequest request);
        Task<ApiResponse> DeletePermissionDefinition(DeletePermissionDefinitionRequest request);
    }
}
