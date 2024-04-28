using Application.Models.Identity.User;


namespace Application.Contracts.Identity
{
    public interface IUserService
    {
        public string UserId { get; }

        public Task<UserInfoResponse> GetUserInfo(UserInfoRequest request);

        public Task<UserInfoResponse> GetCurrentUser();
    }
}
