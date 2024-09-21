using BlazorUI.Models;
using BlazorUI.Models.User;

namespace BlazorUI.Contracts
{
    public interface IUserService
    {
        Task<UserInfoVM> GetUserInfo(string userName);
        Task<UsersPaginationVM> GetUsersByUsernameWithPagination(string? userName, int pageIndex, int pageSize);

        Task<ApiResponseVM> ChangeUserSettings(ChangeUserSettingsRequestVM request);

    }
}
