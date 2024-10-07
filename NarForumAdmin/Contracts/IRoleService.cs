using NarForumAdmin.Models;
using NarForumAdmin.Models.Authorization.Role;

namespace NarForumAdmin.Contracts
{
    public interface IRoleService
    {
        Task<ApiResponseVM> AddRole(AddRoleRequestVM request);
        Task<ApiResponseVM> UpdateRole(UpdateRoleRequestVM request);
        Task<ApiResponseVM> RemoveRole(RemoveRoleRequestVM request);
        Task<GetUserRolesResponseVM> GetRoles();
    }
}
