using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Extensions;
using BlazorUI.Models.Authorization;
using BlazorUI.Models.User;

namespace BlazorUI.Services
{
    public class AuthorizationService
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        private List<PermissionVM> permissions = new List<PermissionVM>();
        private List<PermissionVM> Permissions
        {
            get
            {
                return permissions;
            }
        }

        Dictionary<string, bool> PermissionsValues { get; set; } = new Dictionary<string, bool>();

        public AuthorizationService(IUserService userService,IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        public async Task SetPermissions(string userName)
        {
            var userInfo = await _userService.GetUserInfo(userName);

            if (userInfo != null) 
            {
                var getUserRoleRequest = new GetApiUserRoleRequestVM {
                    Id = userInfo.Id,
                };

                var userRole = await _userService.GetApiUserRole(getUserRoleRequest);

                if(userRole is not null)
                {
                    GetPermissionsResponseVM response = await _permissionService.GetPermissions(userRole.RoleId);

                    if (response is not null && response.Permissions is not null && response.Permissions.Count > 0)
                    {
                        PermissionsValues.Clear();
                        permissions = response.Permissions;

                        foreach (var permission in Permissions)
                        {
                            if (permission.Name is not null)
                            {
                                PermissionsValues.Add(permission.Name, permission.IsGranted);
                            }
                        }
                        AuthExtension.SetPermission(PermissionsValues);
                    }
                }
            }
        }

        
    }
}
