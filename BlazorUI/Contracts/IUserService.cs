using BlazorUI.Models.User;

namespace BlazorUI.Contracts
{
    public interface IUserService
    {
        Task<UserInfoVM> GetUserInfo(string userName);
    }
}
