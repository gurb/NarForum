using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Models;
using Application.Models.Identity.User;
using Application.Models.Persistence.Image;
using Identity.DatabaseContext;
using Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ForumUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ForumIdentityDbContext _identityDbContext;
        private readonly IImageService _imageService;

        public UserService(UserManager<ForumUser> userManager, IHttpContextAccessor contextAccessor, ForumIdentityDbContext identityDbContext, IImageService imageService)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _identityDbContext = identityDbContext;
            _imageService = imageService;
        }

        public string GetUserId()
        {
            return UserId;
        }

        public string UserId { get { return _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); } }

        public async Task<UserInfoResponse> GetCurrentUser()
        {
            string id = UserId;
            var currentUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            UserInfoResponse response = new UserInfoResponse
            {
                UserName = currentUser.UserName,
                RegisterDate = currentUser.RegisterDate,
            };

            return response;
        }





        public async Task<UserInfoResponse> GetUserInfo(UserInfoRequest request)
        {
            var user = await _identityDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == request.UserName);

            UserInfoResponse response;

            if (user is not null)
            {
                response = new UserInfoResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RegisterDate = user.RegisterDate,
                    Description = user.Description,
                    PostCounter = 100,
                    HeadingCounter = 10,
                };
            }
            else
            {
                response = new UserInfoResponse();
            }

            return response;
        }

        public async Task<UsersPaginationDTO> GetWithPagination(GetUsersWithPaginationQuery query)
        {
            UsersPaginationDTO dto = new UsersPaginationDTO();

            var predicate = PredicateBuilder.True<ForumUser>();

            if(!String.IsNullOrEmpty(query.UserName))
            {
                predicate = predicate.And(x => x.UserName!.Contains(query.UserName));
            }

            var users = await _identityDbContext.Users.AsNoTracking()
                .Where(predicate)
                .Skip((query.PageIndex! - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(x => new UserInfoResponse
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        RegisterDate = x.RegisterDate,
                        Description = x.Description,
                        PostCounter = 100,
                        HeadingCounter = 10
                    }
                ).ToListAsync();
            
            dto.Users = users;
            dto.TotalCount = _identityDbContext.Users.AsNoTracking()
                .Where(predicate).Count();

            return dto;
        }

        public async Task<ApiResponse> ChangeUserSettings(ChangeUserSettingsRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var user = await GetCurrentUser();


                if(user != null)
                {

                    if(request.IsChangeImage)
                    {
                        if(request.ProfileImage != null)
                        {
                            UploadImageRequest uploadRequest = new UploadImageRequest
                            {
                                UserId = new Guid(user.Id!),
                                Type = Application.Models.Enums.UploadImageType.UserProfile,
                                Dir = request.Dir,
                                Files = new List<IFormFile> { request.ProfileImage }
                            };

                            ApiResponse uploadResponse = await _imageService.UploadImageToServer(uploadRequest);

                            if (!uploadResponse.IsSuccess)
                            {
                                return response;
                            }
                        }
                    }

                    var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

                    if(updateUser != null)
                    {
                        updateUser.UserName = request.UserName;

                        _identityDbContext.Users.Update(updateUser);
                        await _identityDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "User cannot find";
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Not found any authenticated user";
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
