using Application.Contracts.Identity;
using Application.Models;
using Application.Models.Identity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("GetUserInfo")]
        public async Task<UserInfoResponse> Register(UserInfoRequest request)
        {
            return await _userService.GetUserInfo(request);
        }

        [HttpPost("GetUsersWithPagination")]
        public async Task<UsersPaginationDTO> GetUsersWithPagination(GetUsersWithPaginationQuery request)
        {
            return await _userService.GetWithPagination(request);
        }

        [HttpPost("ChangeUserSettings")]
        public async Task<ApiResponse> ChangeUserSettings([FromBody]ChangeUserSettingsRequest request)
        {
            var dir = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads", "Images");
            request.Dir = dir;
            return await _userService.ChangeUserSettings(request);
        }

        [HttpPost("UpdateUser")]
        public async Task<ApiResponse> UpdateUser([FromBody] UpdateUserRequest request)
        {
            return await _userService.UpdateUser(request);
        }

        [HttpPost("BlockUser")]
        public async Task<ApiResponse> BlockUser([FromBody] string? userId)
        {
            return await _userService.BlockUser(userId);
        }
    }
}
