using NarForumAdmin.Models;
using NarForumAdmin.Models.Authorization.Permission;
using NarForumAdmin.Services.Base;

namespace NarForumAdmin.Contracts
{
    public interface IPermissionService
    {
        Task<ApiResponseVM> RefreshPermissions();
        Task<ApiResponseVM> ResetPermissions();
        Task<ApiResponseVM> SetPermission(SetPermissionRequestVM request);
        Task<ApiResponseVM> ChangePermissionStatus(string permissionId);
        Task<GetPermissionDefinitionsResponseVM> GetPermissionDefinitions();
        Task<GetPermissionsResponseVM> GetPermissions();
        Task<GetPermissionsResponseVM> GetPermissions(string roleId);
        Task<ApiResponseVM> AddPermissionDefinition(AddPermissionDefinitionRequestVM request);
        Task<ApiResponseVM> UpdatePermissionDefinition(UpdatePermissionDefinitionRequestVM request);
        Task<ApiResponseVM> DeletePermissionDefinition(DeletePermissionDefinitionRequestVM request);
    }
}
