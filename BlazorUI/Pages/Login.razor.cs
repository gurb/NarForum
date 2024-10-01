using BlazorUI.Contracts;
using Microsoft.AspNetCore.Components;
using BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using BlazorUI.Services.Common;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorUI.Services.UI;
using BlazorUI.Models.Logo;
using BlazorUI.Services;

namespace BlazorUI.Pages;

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

            hubConnection = new HubConnectionBuilder()
            .WithUrl(
                $"https://localhost:44342/track",
                o => {
                    o.AccessTokenProvider = () => Task.FromResult<string?>(token);
                    o.Url = new Uri($"https://localhost:44342/track?username={username}&group={group}");
                    o.SkipNegotiation = true;
                    o.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                }
            )
            .Build();


            hubConnection.Closed += async (error) =>
            {
                if(error != null)
                {
                    // hata meydana gelirse yeniden bağlamı işini burada yap
                }
                else
                {
                    // kapat
                    await hubConnection.StopAsync();
                }
            };

            await hubConnection.StartAsync();

            if(RefreshStateService.ConnectChatHubWhenLogin != null)
            {
                await RefreshStateService.ConnectChatHubWhenLogin.Invoke();
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