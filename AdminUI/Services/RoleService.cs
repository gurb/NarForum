using AdminUI.Contracts;
using AdminUI.Models;
using AdminUI.Models.Authorization.Role;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using AutoMapper;

namespace AdminUI.Services
{
    public class RoleService : BaseHttpService, IRoleService
    {
        private readonly IMapper _mapper;
        public RoleService(IMapper mapper, IClient client, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> AddRole(AddRoleRequestVM request)
        {
            var addRoleRequest = _mapper.Map<AddRoleRequest>(request);
            var response = await _client.AddUserRoleAsync(addRoleRequest);

            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<GetUserRolesResponseVM> GetRoles()
        {
            var response = await _client.GetUserRolesAsync();

            return _mapper.Map<GetUserRolesResponseVM>(response);
        }

        public async Task<ApiResponseVM> RemoveRole(RemoveRoleRequestVM request)
        {
            var removeRoleRequest = _mapper.Map<RemoveRoleRequest>(request);
            var response = await _client.RemoveUserRoleAsync(removeRoleRequest);

            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<ApiResponseVM> UpdateRole(UpdateRoleRequestVM request)
        {
            var updateRoleRequest = _mapper.Map<UpdateRoleRequest>(request);
            var response = await _client.UpdateUserRoleAsync(updateRoleRequest);

            return _mapper.Map<ApiResponseVM>(response);
        }
    }
}
