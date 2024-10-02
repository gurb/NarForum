using GurbForumUser.Client.Models;
using GurbForumUser.Client.Services.Base;

namespace GurbForumUser.Client.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<ApiResponseVM> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}
