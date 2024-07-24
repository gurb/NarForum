using AdminUI.Contracts;
using AdminUI.Models;
using AdminUI.Models.Authorization.Permission;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using AutoMapper;

namespace AdminUI.Services
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
            var addPermissionDefinition = _mapper.Map<AddPermissionDefinitionRequest>(request);
            var response = await _client.AddPermissionDefinitionAsync(addPermissionDefinition);

            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<ApiResponseVM> ChangePermissionStatus(string permissionId)
        {
            var response = await _client.ChangePermissionStatusAsync(permissionId);

            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<ApiResponseVM> DeletePermissionDefinition(DeletePermissionDefinitionRequestVM request)
        {
            var deletePermissionDefinition = _mapper.Map<DeletePermissionDefinitionRequest>(request);
            var response = await _client.DeletePermissionDefinitionAsync(deletePermissionDefinition);

            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<GetPermissionDefinitionsResponseVM> GetPermissionDefinitions()
        {
            var response = await _client.GetPermissionDefinitionsAsync();

            return _mapper.Map<GetPermissionDefinitionsResponseVM>(response);
        }

        public async Task<GetPermissionsResponseVM> GetPermissions()
        {
            var response = await _client.GetPermissionsAsync();

            return _mapper.Map<GetPermissionsResponseVM>(response);
        }

        public async Task<GetPermissionsResponseVM> GetPermissions(string roleId)
        {
            var response = await _client.GetPermissionsByRoleIdAsync(roleId);

            return _mapper.Map<GetPermissionsResponseVM>(response);
        }

        public async Task<ApiResponseVM> RefreshPermissions()
        {
            var response = await _client.RefreshPermissionsAsync();

            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<ApiResponseVM> ResetPermissions()
        {
            var response = await _client.ResetPermissionsAsync();

            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<ApiResponseVM> SetPermission(SetPermissionRequestVM request)
        {
            var setPermissionRequest = _mapper.Map<SetPermissionRequest>(request);
            var response = await _client.SetPermissionAsync(setPermissionRequest);

            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<ApiResponseVM> UpdatePermissionDefinition(UpdatePermissionDefinitionRequestVM request)
        {
            var updatePermissionDefinitionRequest = _mapper.Map<UpdatePermissionDefinitionRequest>(request);
            var response = await _client.UpdatePermissionDefinitionAsync(updatePermissionDefinitionRequest);

            return _mapper.Map<ApiResponseVM>(response);
        }
    }
}
