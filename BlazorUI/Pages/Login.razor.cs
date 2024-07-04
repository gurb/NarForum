using BlazorUI.Contracts;
using Microsoft.AspNetCore.Components;
using BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using BlazorUI.Services.Common;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorUI.Pages;

public partial class Login: IAsyncDisposable
{
    public LoginVM Model { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public string Message { get; set; }

    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }

    private HubConnection? hubConnection;
    [Inject]
    LocalStorageService localStorage { get; set; }

    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

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