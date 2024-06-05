using AdminUI.Models;
using AdminUI.Models.Authentication.Role;

namespace AdminUI.Contracts
{
    public interface IRoleService
    {
        Task<ApiResponseVM> AddRole(AddRoleRequestVM request);
        Task<ApiResponseVM> UpdateRole(UpdateRoleRequestVM request);
        Task<GetUserRolesResponseVM> GetRoles();
    }
}
