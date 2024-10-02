using AutoMapper;
using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models.Authorization;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;

namespace GurbForumUser.Client.Services
{
    public class PermissionService : BaseHttpService, IPermissionService
    {
        private readonly IMapper _mapper;

        public PermissionService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<GetPermissionsResponseVM> GetPermissions(string roleId)
        {
            var response = await _client.GetPermissionsByRoleIdAsync(roleId);

            return _mapper.Map<GetPermissionsResponseVM>(response);
        }
    }
}
