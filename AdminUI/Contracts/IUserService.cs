using AdminUI.Models.User;

namespace AdminUI.Contracts
{
    public interface IUserService
    {
        Task<UserInfoVM> GetUserInfo(string userName);
    }
}
