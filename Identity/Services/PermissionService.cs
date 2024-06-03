using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.Permission;
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
                    response.IsSuccess = true;
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
                    _forumIdentityDbContext.PermissionDefinitions.Update(permissionDefinition);
                    await _forumIdentityDbContext.SaveChangesAsync();
                    response.Message = "Updated permisson definition";
                    response.IsSuccess = true;
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
