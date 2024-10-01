using BlazorUI.Models.Authorization;

namespace BlazorUI.Contracts
{
    public interface IPermissionService
    {
        Task<GetPermissionsResponseVM> GetPermissions(string roleId);
    }
    
}
