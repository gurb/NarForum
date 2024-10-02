using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using GurbForumUser.Client.Models.Section;
using GurbForumUser.Client.Services.UI;
using GurbForumUser.Client.Pages.Category.Modal;
using GurbForumUser.Client.Pages.Sections.Modal;

namespace GurbForumUser.Client.Pages;

public partial class Index
{

    [CascadingParameter]
    public bool isBot { get; set; }
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }

    [Inject]
    public ISectionService SectionsService { get; set; }

    [Inject]
    public RefreshStateService RefreshStateService { get; set; }

    

    protected async override Task OnInitializedAsync()
    {
        if(!isBot)
        {
            await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }
    }

    protected void GoToLogin()
    {
        NavigationManager.NavigateTo("login/");
    }



    protected void GoToRegister()
    {
        NavigationManager.NavigateTo("register/");
    }

    protected async void Logout()
    {
        await AuthenticationService.Logout();
    }


}