using BlazorUI.Contracts;
using Microsoft.AspNetCore.Components;
using BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using BlazorUI.Services.Common;

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

            hubConnection = new HubConnectionBuilder()
            .WithUrl(
                "https://localhost:7147/track",
                o => {
                    o.AccessTokenProvider = () => Task.FromResult<string?>(token);
                    o.Url = new Uri($"https://localhost:7147/track?username={Model.Email}");
                }
            )
            .Build();

            await hubConnection.StartAsync();

        }
        Message = "Username/password combination unknown";
    }

    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}