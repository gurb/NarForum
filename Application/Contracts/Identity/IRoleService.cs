using Application.Models;
using Application.Models.Identity.Role;

namespace Application.Contracts.Identity
{
    public interface IRoleService
    {
        public Task<ApiResponse> AddRole(AddRoleRequest request);
        public Task<ApiResponse> UpdateRole(UpdateRoleRequest request);
        public Task<ApiResponse> RemoveRole(RemoveRoleRequest request);
        public Task<GetUserRolesResponse> GetRoles();
    }
}
