using NarForumUser.Client.Models.Authorization;

namespace NarForumUser.Client.Contracts
{
    public interface IPermissionService
    {
        Task<GetPermissionsResponseVM> GetPermissions(string roleId);
    }
    
}
