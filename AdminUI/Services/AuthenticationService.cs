using AdminUI.Contracts;
using AdminUI.Providers;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using Microsoft.AspNetCore.Components.Authorization;


namespace AdminUI.Services;

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
            var tct = ex.Message.ToString();
            return false;
        }

        return false;
    }

    public async Task Logout()
    {
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, UserName = userName, Email = email, Password = password };

        var response = await _client.RegisterAsync(registrationRequest);

        if (response.IsSuccess)
        {
            return true;
        }
        return false;
    }
}
