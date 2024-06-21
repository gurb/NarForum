using Application.Models.Identity.User;
using System.Linq.Expressions;


namespace Application.Contracts.Identity
{
    public interface IUserService
    {
        public string UserId { get; }

        public string GetUserId();
        public Task<UserInfoResponse> GetUserInfo(UserInfoRequest request);

        public Task<UserInfoResponse> GetCurrentUser();

        public Task<UsersPaginationDTO> GetWithPagination(GetUsersWithPaginationQuery query);
    }
}
