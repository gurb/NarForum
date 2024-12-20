using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using Microsoft.AspNetCore.Components;
using NarForumAdmin.Models.Authentication;
using NarForumAdmin.Models.Logo;

namespace NarForumAdmin.Pages;

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
        var response = await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password);
        if (response.IsSuccess)
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            if(response.Message is not null)
            {
                Message = response.Message;
            }
            else
            {
                Message = "Username/password combination unknown";
            }
        }
    }
}