using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.Authorization;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

namespace NarForumUser.Client.Services
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
