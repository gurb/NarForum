using Application.Contracts.Identity;
using Application.Extensions.Core;
using Application.Models.Identity.User;
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

        public UserService(UserManager<ForumUser> userManager, IHttpContextAccessor contextAccessor, ForumIdentityDbContext identityDbContext)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _identityDbContext = identityDbContext;
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

            UserInfoResponse response = new UserInfoResponse
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RegisterDate = user.RegisterDate,
                Description = user.Description,
                PostCounter = 100,
                HeadingCounter = 10,
            };

            return response;
        }

        public async Task<UsersPaginationDTO> GetWithPagination(GetUsersWithPaginationQuery query)
        {
            UsersPaginationDTO dto = new UsersPaginationDTO();

            var predicate = PredicateBuilder.True<ForumUser>();

            if(!String.IsNullOrEmpty(query.UserName))
            {
                predicate = predicate.And(x => x.UserName == query.UserName);
            }

            var users = await _identityDbContext.Users.AsNoTracking()
                .Where(predicate)
                .Skip((query.PageIndex! - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(x => new UserInfoResponse
                    {
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

    }
}
