using BlazorUI.Models;
using BlazorUI.Models.User;

namespace BlazorUI.Contracts
{
    public interface IUserService
    {
        Task<UserInfoVM> GetUserInfo(string userName);
        Task<UsersPaginationVM> GetUsersByUsernameWithPagination(string? userName, int pageIndex, int pageSize);

        Task<ApiResponseVM> ChangeUserSettings(ChangeUserSettingsRequestVM request);

        public Task<ApiResponseVM> CreateResetPasswordRequest(ResetPasswordRequestVM request);
        public Task<ApiResponseVM> CheckResetPasswordRequest(Guid? Id);
        public Task<ApiResponseVM> ChangeUserPassword(Guid? Id, string? password, string? confirmPassword);

        public Task<ApiResponseVM> CreateConfirmRequest();

        public Task<ApiResponseVM> VerifyEmailAddress(Guid? Id);
    }
}
