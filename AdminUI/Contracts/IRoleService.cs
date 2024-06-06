using AdminUI.Models;
using AdminUI.Models.Authorization.Role;

namespace AdminUI.Contracts
{
    public interface IRoleService
    {
        Task<ApiResponseVM> AddRole(AddRoleRequestVM request);
        Task<ApiResponseVM> UpdateRole(UpdateRoleRequestVM request);
        Task<ApiResponseVM> RemoveRole(RemoveRoleRequestVM request);
        Task<GetUserRolesResponseVM> GetRoles();
    }
}
