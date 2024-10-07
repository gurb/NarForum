using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Authorization.Permission;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
{
    public class PermissionService : BaseHttpService, IPermissionService
    {
        private readonly IMapper _mapper;

        public PermissionService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }
        public async Task<ApiResponseVM> AddPermissionDefinition(AddPermissionDefinitionRequestVM request)
        {
            try
            {
                var addPermissionDefinition = _mapper.Map<AddPermissionDefinitionRequest>(request);
                var response = await _client.AddPermissionDefinitionAsync(addPermissionDefinition);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> ChangePermissionStatus(string permissionId)
        {
            try
            {
                var response = await _client.ChangePermissionStatusAsync(permissionId);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> DeletePermissionDefinition(DeletePermissionDefinitionRequestVM request)
        {
            
            try
            {
                var deletePermissionDefinition = _mapper.Map<DeletePermissionDefinitionRequest>(request);
                var response = await _client.DeletePermissionDefinitionAsync(deletePermissionDefinition);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<GetPermissionDefinitionsResponseVM> GetPermissionDefinitions()
        {
            
            try
            {
                var response = await _client.GetPermissionDefinitionsAsync();

                return _mapper.Map<GetPermissionDefinitionsResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<GetPermissionsResponseVM> GetPermissions()
        {
            try
            {
                var response = await _client.GetPermissionsAsync();

                return _mapper.Map<GetPermissionsResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<GetPermissionsResponseVM> GetPermissions(string roleId)
        {
            
            try
            {
                var response = await _client.GetPermissionsByRoleIdAsync(roleId);

                return _mapper.Map<GetPermissionsResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> RefreshPermissions()
        {
            
            try
            {
                var response = await _client.RefreshPermissionsAsync();

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> ResetPermissions()
        {
            
            try
            {
                var response = await _client.ResetPermissionsAsync();

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> SetPermission(SetPermissionRequestVM request)
        {
            try
            {
                var setPermissionRequest = _mapper.Map<SetPermissionRequest>(request);
                var response = await _client.SetPermissionAsync(setPermissionRequest);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdatePermissionDefinition(UpdatePermissionDefinitionRequestVM request)
        {
            try
            {
                var updatePermissionDefinitionRequest = _mapper.Map<UpdatePermissionDefinitionRequest>(request);
                var response = await _client.UpdatePermissionDefinitionAsync(updatePermissionDefinitionRequest);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
