﻿using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models.Authorization;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
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
