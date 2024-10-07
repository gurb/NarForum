using NarForumAdmin.Contracts;
using NarForumAdmin.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace NarForumAdmin.Pages;

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
        var result = await AuthenticationService.RegisterAsync(Model.FirstName, Model.LastName, Model.UserName, Model.Email, Model.Password);

        if (result)
        {
            NavigationManager.NavigateTo("/");
        }
        Message = "Something went wrong, please try again.";
    }
}