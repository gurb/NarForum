using AdminUI.Models;
using AdminUI.Models.Authorization.Permission;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
{
    public interface IPermissionService
    {
        Task<ApiResponseVM> RefreshPermissions();
        Task<ApiResponseVM> ResetPermissions();
        Task<ApiResponseVM> SetPermission(SetPermissionRequestVM request);
        Task<GetPermissionDefinitionsResponseVM> GetPermissionDefinitions();
        Task<GetPermissionsResponseVM> GetPermissions();
        Task<ApiResponseVM> AddPermissionDefinition(AddPermissionDefinitionRequestVM request);
        Task<ApiResponseVM> UpdatePermissionDefinition(UpdatePermissionDefinitionRequestVM request);
        Task<ApiResponseVM> DeletePermissionDefinition(DeletePermissionDefinitionRequestVM request);
    }
}
