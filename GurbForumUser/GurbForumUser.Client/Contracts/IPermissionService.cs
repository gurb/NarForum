using GurbForumUser.Client.Models.Authorization;

namespace GurbForumUser.Client.Contracts
{
    public interface IPermissionService
    {
        Task<GetPermissionsResponseVM> GetPermissions(string roleId);
    }
    
}
