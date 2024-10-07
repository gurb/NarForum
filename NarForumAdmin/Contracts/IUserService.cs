using NarForumAdmin.Models;
using NarForumAdmin.Models.User;

namespace NarForumAdmin.Contracts
{
    public interface IUserService
    {
        Task<UserInfoVM> GetUserInfo(string userName);
        Task<ApiUserRoleResponseVM> GetApiUserRole(GetApiUserRoleRequestVM request);

        Task<UsersPaginationVM> GetWithPagination(UsersPaginationQueryVM paramQuery);

        Task<ApiResponseVM> UpdateUser(UpdateUserRequestVM request);
        Task<ApiResponseVM> BlockUser(string? userId);

        Task<ApiResponseVM> CreateResetPasswordRequest(ResetPasswordRequestVM request);
        Task<ApiResponseVM> CheckResetPasswordRequest(Guid? Id);
        Task<ApiResponseVM> ChangeUserPassword(Guid? Id, string? password, string? confirmPassword);

        Task<ApiResponseVM> CreateConfirmRequest();

        Task<ApiResponseVM> VerifyEmailAddress(Guid? Id);
    }
}
