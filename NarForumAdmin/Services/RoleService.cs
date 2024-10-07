using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Authorization.Role;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
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
            
            try
            {
                var addRoleRequest = _mapper.Map<AddRoleRequest>(request);
                var response = await _client.AddUserRoleAsync(addRoleRequest);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<GetUserRolesResponseVM> GetRoles()
        {
            try
            {
                var response = await _client.GetUserRolesAsync();

                return _mapper.Map<GetUserRolesResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> RemoveRole(RemoveRoleRequestVM request)
        {
            try
            {
                var removeRoleRequest = _mapper.Map<RemoveRoleRequest>(request);
                var response = await _client.RemoveUserRoleAsync(removeRoleRequest);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateRole(UpdateRoleRequestVM request)
        {
            try
            {
                var updateRoleRequest = _mapper.Map<UpdateRoleRequest>(request);
                var response = await _client.UpdateUserRoleAsync(updateRoleRequest);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
