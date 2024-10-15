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

        /// <summary>
        /// Gets user information by username
        /// </summary>
        /// <param name="request">The request containing UserName(string) field.</param>
        /// <returns>The getting user information result as UserInfoResponse</returns>
        [HttpPost("GetUserInfo")]
        public async Task<UserInfoResponse> GetUserInfo(UserInfoRequest request)
        {
            return await _userService.GetUserInfo(request);
        }

        /// <summary>
        /// Gets users list related the list of user id.
        /// </summary>
        /// <param name="Ids">The list of user id</param>
        /// <returns>The list of user information as result</returns>
        [AllowAnonymous]
        [HttpPost("GetUsersByUserIds")]
        public async Task<List<UserInfoResponse>> GetUsersByUserIds(List<string> Ids)
        {
            return await _userService.GetUsersByIds(Ids);
        }

        /// <summary>
        /// Gets users with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing UserName, PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of user information and total size of the users</returns>
        [HttpPost("GetUsersWithPagination")]
        public async Task<UsersPaginationDTO> GetUsersWithPagination(GetUsersWithPaginationQuery request)
        {
            return await _userService.GetWithPagination(request);
        }

        /// <summary>
        /// Changes user settings.
        /// </summary>
        /// <param name="request">The request containing user settings fields.</param>
        /// <returns>The changing users settings result as ApiResponse</returns>
        [HttpPost("ChangeUserSettings")]
        public async Task<ApiResponse> ChangeUserSettings([FromBody]ChangeUserSettingsRequest request)
        {
            var dir = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads", "Images");
            request.Dir = dir;
            return await _userService.ChangeUserSettings(request);
        }

        /// <summary>
        /// Updates the selected user.
        /// </summary>
        /// <param name="request">The request containing user information fields.</param>
        /// <returns>The updating user result as ApiResponse</returns>
        [HttpPost("UpdateUser")]
        public async Task<ApiResponse> UpdateUser([FromBody] UpdateUserRequest request)
        {
            return await _userService.UpdateUser(request);
        }

        /// <summary>
        /// Blocks the selected user.
        /// </summary>
        /// <param name="userId">User Id(string)</param>
        /// <returns></returns>
        [HttpPost("BlockUser")]
        public async Task<ApiResponse> BlockUser([FromBody] string? userId)
        {
            return await _userService.BlockUser(userId);
        }

        /// <summary>
        /// Creates the reset password request.
        /// </summary>
        /// <param name="request">The request containing Email(string) field.</param>
        /// <returns>The creating the reset password result as ApiResponse</returns>
        [AllowAnonymous]
        [HttpPost("CreateResetPasswordRequest")]
        public async Task<ApiResponse> CreateResetPasswordRequest([FromBody] ResetPasswordRequest request)
        {
            return await _userService.CreateResetPasswordRequest(request);
        }

        /// <summary>
        /// Checks the result password request.
        /// </summary>
        /// <param name="Id">The password request ID(Guid)</param>
        /// <returns>The checking the reset password result as ApiResponse</returns>
        [AllowAnonymous]
        [HttpPost("CheckResetPasswordRequest")]
        public async Task<ApiResponse> CheckResetPasswordRequest(Guid? Id)
        {
            return await _userService.CheckResetPasswordRequest(Id);
        }

        /// <summary>
        /// Changes the user password
        /// </summary>
        /// <param name="Id">The user's Id (Guid)</param>
        /// <param name="password">The new password</param>
        /// <param name="confirmPassword">The new password as confirm</param>
        /// <returns>The changing the user's password result as ApiResponse</returns>
        [AllowAnonymous]
        [HttpPost("ChangeUserPassword")]
        public async Task<ApiResponse> ChangeUserPassword(Guid? Id, string? password, string? confirmPassword)
        {
            return await _userService.ChangeUserPassword(Id, password, confirmPassword);
        }

        /// <summary>
        /// Creates email confirm request for a new member.
        /// </summary>
        /// <returns>The creating email confirm result as ApiResponse</returns>
        [HttpPost("CreateConfirmRequest")]
        public async Task<ApiResponse> CreateConfirmRequest()
        {
            return await _userService.CreateConfirmRequest();
        }

        /// <summary>
        /// Verifies user's email address.
        /// </summary>
        /// <param name="Id">Verify Id(Guid)</param>
        /// <returns>The verifying user's email address result as ApiResponse</returns>
        [AllowAnonymous]
        [HttpPost("VerifyEmailAddress")]
        public async Task<ApiResponse> VerifyEmailAddress(Guid? Id)
        {
            return await _userService.VerifyEmailAddress(Id);
        }

        /// <summary>
        /// Gets the selected user role.
        /// </summary>
        /// <param name="request">The request containing the user's Id (string) field.</param>
        /// <returns>The getting the selected user role result as ApiUserRoleResponse. This response contains RoleId,
        /// IsSuccess and Message fields.</returns>
        [HttpPost("GetUserRole")]
        public async Task<ApiUserRoleResponse> GetUserRole([FromBody] GetApiUserRoleRequest request)
        {
            return await _userService.GetUserRole(request);
        }
    }
}
