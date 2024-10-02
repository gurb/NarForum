using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace GurbForumUser.Client.Pages;

public partial class Register
{
    public RegisterVM Model { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public string Message { get; set; }

    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }

    protected override void OnInitialized()
    {
        Model = new RegisterVM();
    }

    protected async Task HandleRegister()
    {
        Message = string.Empty;

        var result = await AuthenticationService.RegisterAsync(Model.FirstName, Model.LastName, Model.UserName, Model.Email, Model.Password);

        if (result.IsSuccess)
        {
            NavigationManager.NavigateTo("/login/");
        }
        else
        {
            Message = result.Message;
        }
    }
}