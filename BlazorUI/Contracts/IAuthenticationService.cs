using BlazorUI.Models;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<ApiResponseVM> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}
