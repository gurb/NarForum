using NarForumAdmin.Models.Authentication;

namespace NarForumAdmin.Contracts
{
    public interface IAuthenticationService
    {
        Task<AuthResponseVM> AuthenticateAsync(string email, string password);
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}
