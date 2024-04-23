using Application.Contracts.Identity;
using Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ForumUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ForumUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string UserId { get { return _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); } }
    }
}
