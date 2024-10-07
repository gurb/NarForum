using NarForumAdmin.Contracts;
using NarForumAdmin.Providers;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using Microsoft.AspNetCore.Components.Authorization;


namespace NarForumAdmin.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(IClient client, LocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password, IsAdminPanel = true };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);

            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.AddItem("token", authenticationResponse.Token);
                string token = await _localStorage.GetItem("token");
                // Set claims in Blazor and login state
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                return true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }

        return false;
    }

    public async Task Logout()
    {
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
    {
        try
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, UserName = userName, Email = email, Password = password };

            var response = await _client.RegisterAsync(registrationRequest);

            if (response.IsSuccess)
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}
