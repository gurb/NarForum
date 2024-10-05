using AdminUI.Contracts;
using AdminUI.Models;
using Microsoft.AspNetCore.Components;
using AdminUI.Models.Authentication;
using AdminUI.Models.Logo;

namespace AdminUI.Pages;

public partial class Login
{
    public LoginVM Model { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public string Message { get; set; }

    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }

    LogoVM logoVM { get; set; }

    public Login()
    {
        logoVM = new LogoVM();
        logoVM.Text = "NarForum";
        logoVM.AltText = "NarForum";
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
        }
        Message = "Username/password combination unknown";
    }
}