using AdminUI.Models;
using AdminUI.Models.User;

namespace AdminUI.Contracts
{
    public interface IUserService
    {
        Task<UserInfoVM> GetUserInfo(string userName);

        Task<UsersPaginationVM> GetWithPagination(UsersPaginationQueryVM paramQuery);

        Task<ApiResponseVM> UpdateUser(UpdateUserRequestVM request);
        Task<ApiResponseVM> BlockUser(string? userId);
    }
}
