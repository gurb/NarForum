using Application.Contracts.Identity;
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

        public async Task<UserInfoResponse> GetUserInfo(UserInfoRequest request)
        {
            UserInfoResponse response = new UserInfoResponse();

            var user = await _identityDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.UserId.ToString());

            response.UserName = user.UserName;

            return response;
        }
    }
}
