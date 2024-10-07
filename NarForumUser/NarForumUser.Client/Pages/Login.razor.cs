using NarForumUser.Client.Contracts;
using Microsoft.AspNetCore.Components;
using NarForumUser.Client.Models.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using NarForumUser.Client.Services.Common;
using Microsoft.AspNetCore.Components.Authorization;
using NarForumUser.Client.Services.UI;
using NarForumUser.Client.Models.Logo;
using NarForumUser.Client.Services;

namespace NarForumUser.Client.Pages;

public partial class Login: IAsyncDisposable
{
    public LoginVM Model { get; set; }

    [Inject]
    public AuthorizationService? AuthorizationService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public string Message { get; set; }

    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }

    private HubConnection? hubConnection;
    [Inject]
    LocalStorageService localStorage { get; set; }

    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    [Inject]
    public RefreshStateService RefreshStateService { get; set; }

    LogoVM LogoVM { get; set; } = new LogoVM();

    public Login()
    {
    }

    protected override void OnInitialized()
    {
        Model = new LoginVM();
    }

    protected async override Task OnInitializedAsync()
    {
        
    }


    protected async Task HandleLogin()
    {
        if (await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password))
        {
            NavigationManager.NavigateTo("/");

            string token = await localStorage.GetItem("token");
            
            string group = "forum";

            var authState = await authenticationStateTask;
            var user = authState.User;
            string username = string.Empty;
            if (user.Identity.IsAuthenticated)
            {
                username = user.Identity.Name;

                if(AuthorizationService is not null)
                {
                    await AuthorizationService.SetPermissions(username);
                }
            }
        }
        Message = "Username/password combination unknown";
    }

    
    public async ValueTask DisposeAsync()
    {
        if(hubConnection != null)
        {
            await hubConnection.StopAsync();
            await hubConnection.DisposeAsync();
        }
    }
}