using Application.Models;
using Application.Models.Identity.User;
using System.Linq.Expressions;


namespace Application.Contracts.Identity
{
    public interface IUserService
    {
        public string UserId { get; }

        public string GetUserId();
        public Task<UserInfoResponse> GetUserInfo(UserInfoRequest request);
        public Task<ApiUserRoleResponse> GetUserRole(GetApiUserRoleRequest UserId);

        public Task<UserInfoResponse> GetCurrentUser();
        public Task<List<UserInfoResponse>> GetUserIdsByName(List<string> userNames);
        public Task<UsersPaginationDTO> GetWithPagination(GetUsersWithPaginationQuery query);

        public Task<ApiResponse> ChangeUserSettings(ChangeUserSettingsRequest request);

        public Task<ApiResponse> UpdateUser(UpdateUserRequest request);
        public Task<ApiResponse> BlockUser(string? UserId);


        public Task<ApiResponse> CreateResetPasswordRequest(ResetPasswordRequest request);
        public Task<ApiResponse> CheckResetPasswordRequest(Guid? Id);
        public Task<ApiResponse> ChangeUserPassword(Guid? Id, string? password, string? confirmPassword);


        public Task<ApiResponse> CreateConfirmRequest();
        public Task<ApiResponse> CreateConfirmRequestWithUserId(string? UserId);
        public Task<ApiResponse> VerifyEmailAddress(Guid? Id);

        public Task IncreasePostCounter(string? Id);
        public Task IncreaseHeadingPostCounter(string? Id);

        public Task<List<UserInfoResponse>> GetUsersByIds(List<string> Ids);
    }
}
