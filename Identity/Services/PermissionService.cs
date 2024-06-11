using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.Permission;
using Azure.Core;
using Identity.DatabaseContext;
using Identity.Models;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace Identity.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly ForumIdentityDbContext _forumIdentityDbContext;


        public PermissionService(ForumIdentityDbContext forumIdentityDbContext)
        {
            _forumIdentityDbContext = forumIdentityDbContext;
        }

        public async Task<ApiResponse> AddPermissionDefinition(AddPermissionDefinitionRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                PermissionDefinition permissionDefinition = new PermissionDefinition
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    DisplayName = request.DisplayName,
                    ParentPermissionDefinitionId = request.ParentPermissionDefinitionId,
                };

                await _forumIdentityDbContext.PermissionDefinitions.AddAsync(permissionDefinition);
                await _forumIdentityDbContext.SaveChangesAsync();

                response.Message = "Added permission definition";

                await RefreshPermissions();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ApiResponse> ChangePermissionStatus(string permissionId)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var permission = await _forumIdentityDbContext.Permissions.FirstOrDefaultAsync(x => x.Id == permissionId);

                if (permission != null)
                {
                    permission.IsGranted = !permission.IsGranted;
                    _forumIdentityDbContext.Permissions.Update(permission);
                    await _forumIdentityDbContext.SaveChangesAsync();
                    response.Message = "Granted permission";
                }
                else
                {
                    response.Message = "Not found";
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ApiResponse> DeletePermissionDefinition(DeletePermissionDefinitionRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                PermissionDefinition? permissionDefinition = await _forumIdentityDbContext.PermissionDefinitions.FirstOrDefaultAsync(x => x.Id == request.PermissionDefinitionId);
                
                if (permissionDefinition != null)
                {
                    _forumIdentityDbContext.PermissionDefinitions.Remove(permissionDefinition);
                    response.Message = "Removed permisson definition";

                    await RefreshPermissions();
                }
                else
                {
                    response.Message = "Not found";
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<GetPermissionDefinitionsResponse> GetPermissionDefinitions()
        {
            GetPermissionDefinitionsResponse response = new GetPermissionDefinitionsResponse();


            response.PermissionDefinitions = await _forumIdentityDbContext.PermissionDefinitions.Select(x => new PermissionDefinitionDTO
            {
                Id = x.Id,
                Name = x.Name,
                DisplayName = x.DisplayName,
                ParentPermissionDefinitionId = x.ParentPermissionDefinitionId,
            }).ToListAsync();

            return response;
        }

        public async Task<GetPermissionsResponse> GetPermissions()
        {
            GetPermissionsResponse response = new GetPermissionsResponse();

            response.Permissions = await _forumIdentityDbContext.Permissions.Select(x => new PermissionDTO 
            {
                Id = x.Id,
                Name = x.Name,
                DisplayName = x.DisplayName,
                IsGranted = x.IsGranted,
                ParentPermissionId = x.ParentPermissionId,
                PermissionDefinitionId = x.PermissionDefinitionId,
                RoleId = x.RoleId,
            }).ToListAsync();

            return response;
        }

        public async Task<GetPermissionsResponse> GetPermissions(string roleId)
        {
            GetPermissionsResponse response = new GetPermissionsResponse();

            response.Permissions = await _forumIdentityDbContext.Permissions.Where(x => x.RoleId == roleId).Select(x => new PermissionDTO
            {
                Id = x.Id,
                Name = x.Name,
                DisplayName = x.DisplayName,
                IsGranted = x.IsGranted,
                ParentPermissionId = x.ParentPermissionId,
                PermissionDefinitionId = x.PermissionDefinitionId,
                RoleId = x.RoleId,
            }).ToListAsync();

            return response;
        }

        public async Task<ApiResponse> RefreshPermissions()
        {
            ApiResponse response = new ApiResponse();

            try
            {
                // create a backup
                var copyThis = await _forumIdentityDbContext.Permissions.AsNoTracking().ToListAsync();
                var oldPermissions = new List<Permission>(copyThis);

                // remove permissions from database
                var list = await _forumIdentityDbContext.Permissions.ToListAsync();
                _forumIdentityDbContext.Permissions.RemoveRange(list);

                var permissionDefinitions = await _forumIdentityDbContext.PermissionDefinitions.AsNoTracking().ToListAsync();
                var roles = await _forumIdentityDbContext.Roles.AsNoTracking().ToListAsync();
                List<Permission> newPermissions = new List<Permission>();

                foreach (var role in roles)
                {
                    foreach (var permissionDefinition in permissionDefinitions)
                    {
                        var permission = new Permission();

                        var oldPermission = oldPermissions.Where(x => x.Name == permission.Name && x.RoleId == role.Id).FirstOrDefault();

                        if (oldPermission != null)
                        {
                            permission.Name = oldPermission.Name;
                            permission.DisplayName = oldPermission.DisplayName;
                            permission.IsGranted = oldPermission.IsGranted;
                            permission.PermissionDefinitionId = oldPermission.PermissionDefinitionId;
                            permission.ParentPermissionId = oldPermission.ParentPermissionId;
                            permission.RoleId = oldPermission.RoleId;
                        }
                        else
                        {
                            permission.Name = permissionDefinition.Name;
                            permission.DisplayName = permissionDefinition.DisplayName;
                            permission.IsGranted = false;
                            permission.PermissionDefinitionId = permissionDefinition.Id;
                            permission.ParentPermissionId = null;
                            permission.RoleId = role.Id;
                        }

                        newPermissions.Add(permission);
                    }
                }

                // set parent Ids of permissions
                foreach (var permission in newPermissions)
                {
                    var permissionDefinition = permissionDefinitions.FirstOrDefault(x => x.Id == permission.PermissionDefinitionId);

                    if(permissionDefinition != null)
                    {
                        if(permissionDefinition.ParentPermissionDefinitionId != null)
                        {
                            var parentPermission = newPermissions.FirstOrDefault(x => x.PermissionDefinitionId == permissionDefinition.ParentPermissionDefinitionId && x.RoleId == permission.RoleId);

                            if (parentPermission != null)
                            {
                                permission.ParentPermissionId = parentPermission.Id;
                            }
                        }
                    }
                }

                _forumIdentityDbContext.Permissions.AddRange(newPermissions);
                await _forumIdentityDbContext.SaveChangesAsync();
                response.Message = "Refreshed permissions";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ApiResponse> ResetPermissions()
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var permissions = await _forumIdentityDbContext.Permissions.ToListAsync();

                foreach (var permission in permissions)
                {
                    permission.IsGranted = false;
                }

                _forumIdentityDbContext.Permissions.UpdateRange(permissions);
                await _forumIdentityDbContext.SaveChangesAsync();
                response.Message = "Resetted permissions";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ApiResponse> SetPermission(SetPermissionRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                Permission? permission = await _forumIdentityDbContext.Permissions.FirstOrDefaultAsync(x => x.Id == request.PermissionId);

                if (permission != null)
                {
                    permission.IsGranted = !permission.IsGranted;


                    _forumIdentityDbContext.Permissions.Update(permission);
                    await _forumIdentityDbContext.SaveChangesAsync();
                    response.Message = "setted permisson";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ApiResponse> UpdatePermissionDefinition(UpdatePermissionDefinitionRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                PermissionDefinition? permissionDefinition = await _forumIdentityDbContext.PermissionDefinitions.FirstOrDefaultAsync(x => x.Id == request.PermissionDefinitionId);

                if (permissionDefinition != null)
                {
                    permissionDefinition.ParentPermissionDefinitionId = request.PermissionDefinitionId;
                    permissionDefinition.Name = request.Name;
                    permissionDefinition.DisplayName = request.DisplayName;

                    _forumIdentityDbContext.PermissionDefinitions.Update(permissionDefinition);
                    await _forumIdentityDbContext.SaveChangesAsync();
                    response.Message = "Updated permisson definition";

                    await RefreshPermissions();
                }
                else
                {
                    response.Message = "Not found";
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }

            return response;
        }
    }
}
