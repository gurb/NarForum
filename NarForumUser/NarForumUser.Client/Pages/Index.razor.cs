using NarForumUser.Client.Contracts;
using NarForumUser.Client.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using NarForumUser.Client.Models.Section;
using NarForumUser.Client.Services.UI;
using NarForumUser.Client.Pages.Category.Modal;
using NarForumUser.Client.Pages.Sections.Modal;
using Microsoft.JSInterop;
using NarForumUser.Client.Models.TrackingLog;

namespace NarForumUser.Client.Pages;

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

    [Inject]
    public IJSRuntime JS { get; set; }

    [Inject]
    public ITrackingLogService? TrackingLogService { get; set; }




    protected async override Task OnInitializedAsync()
    {
        if(!isBot)
        {
            await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();


            if (JS is not IJSInProcessRuntime)
            {
                return;
            }
            
            var cookiePolicyAccepted = await JS.InvokeAsync<string>("GetCookiePolicyAccepted");
            
            if (TrackingLogService is not null && cookiePolicyAccepted == "true")
            {
                AddTrackingLogCommandVM command = new AddTrackingLogCommandVM
                {
                    Type = Models.Enums.TrackingTypeVM.HOMEPAGE,
                    Browser = await JS.InvokeAsync<string>("GetBrowserName")
                };

                await TrackingLogService.AddTrackingLog(command);
            }
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