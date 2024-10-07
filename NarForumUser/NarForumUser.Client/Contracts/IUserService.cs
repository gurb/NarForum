using NarForumUser.Client.Models;
using NarForumUser.Client.Models.User;

namespace NarForumUser.Client.Contracts
{
    public interface IUserService
    {
        Task<UserInfoVM> GetUserInfo(string userName);
        Task<UsersPaginationVM> GetUsersByUsernameWithPagination(string? userName, int pageIndex, int pageSize);
        Task<ApiUserRoleResponseVM> GetApiUserRole(GetApiUserRoleRequestVM request);

        Task<ApiResponseVM> ChangeUserSettings(ChangeUserSettingsRequestVM request);

        public Task<ApiResponseVM> CreateResetPasswordRequest(ResetPasswordRequestVM request);
        public Task<ApiResponseVM> CheckResetPasswordRequest(Guid? Id);
        public Task<ApiResponseVM> ChangeUserPassword(Guid? Id, string? password, string? confirmPassword);

        public Task<ApiResponseVM> CreateConfirmRequest();

        public Task<ApiResponseVM> VerifyEmailAddress(Guid? Id);
    }
}
