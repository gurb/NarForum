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
        public async Task<UserInfoResponse> GetUserInfo(UserInfoRequest request)
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

        [AllowAnonymous]
        [HttpPost("CreateResetPasswordRequest")]
        public async Task<ApiResponse> CreateResetPasswordRequest([FromBody] ResetPasswordRequest request)
        {
            return await _userService.CreateResetPasswordRequest(request);
        }

        [AllowAnonymous]
        [HttpPost("CheckResetPasswordRequest")]
        public async Task<ApiResponse> CheckResetPasswordRequest(Guid? Id)
        {
            return await _userService.CheckResetPasswordRequest(Id);
        }

        [AllowAnonymous]
        [HttpPost("ChangeUserPassword")]
        public async Task<ApiResponse> ChangeUserPassword(Guid? Id, string? password, string? confirmPassword)
        {
            return await _userService.ChangeUserPassword(Id, password, confirmPassword);
        }


        [HttpPost("CreateConfirmRequest")]
        public async Task<ApiResponse> CreateConfirmRequest()
        {
            return await _userService.CreateConfirmRequest();
        }

        [AllowAnonymous]
        [HttpPost("VerifyEmailAddress")]
        public async Task<ApiResponse> VerifyEmailAddress(Guid? Id)
        {
            return await _userService.VerifyEmailAddress(Id);
        }
    }
}
