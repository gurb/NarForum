using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NarForumUser.Client.Models.TrackingLog;

namespace NarForumUser.Client.Pages;

public partial class Register
{
    public RegisterVM Model { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public string Message { get; set; }

    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }

    [Inject]
    public IJSRuntime JS { get; set; }

    [Inject]
    public ITrackingLogService? TrackingLogService { get; set; }

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
            await SaveTrackingLog();
            NavigationManager.NavigateTo("/login/");
        }
        else
        {
            Message = result.Message;
        }
    }

    private async Task SaveTrackingLog()
    {
        if (JS is not IJSInProcessRuntime)
        {
            return;
        }

        var cookiePolicyAccepted = await JS.InvokeAsync<string>("GetCookiePolicyAccepted");

        if (TrackingLogService is not null && cookiePolicyAccepted == "true")
        {
            AddTrackingLogCommandVM command = new AddTrackingLogCommandVM
            {
                Type = Models.Enums.TrackingTypeVM.NEWUSER,
                DateTime = DateTime.UtcNow,
                IsMember = true,
                Browser = await JS.InvokeAsync<string>("GetBrowserName")
            };

            await TrackingLogService.AddTrackingLog(command);
        }
    }
}