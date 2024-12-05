using NarForumUser.Client.Contracts;
using NarForumUser.Client.Handlers;
using NarForumUser.Client.Providers;
using NarForumUser.Client.Services;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;
using NarForumUser.Client.Services.UI;
using NarForumUser.Components;
using NarForumUser.Extensions;
using Microsoft.AspNetCore.Components.Authorization;


var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<JwtAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseUrl")!)).AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

//builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<RefreshStateService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
//builder.Services.AddScoped<AuthenticationStateProvider, PrerenderedAuthenticationStateProvider>();
//builder.Services.AddScoped<AuthenticationStateProvider, PrerenderedAuthenticationStateProvider>();


builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IHeadingService, HeadingService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddScoped<IBlogCategoryService, BlogCategoryService>();
builder.Services.AddScoped<IBlogCommentService, BlogCommentService>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<IPageService, PageService>();

builder.Services.AddScoped<ITrackingLogService, TrackingLogService>();
builder.Services.AddScoped<ILogoService, LogoService>();
builder.Services.AddScoped<IForumSettingsService, ForumSettingsService>();
builder.Services.AddScoped<IForumStatService, ForumStatService>();
builder.Services.AddScoped<ISmtpSettingsService, SmtpSettingsService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

builder.Services.AddSingleton<ToastService>();
builder.Services.AddSingleton<ImageProvider>();

builder.Services.AddAutoMapper(typeof(NarForumUser.Client.MappingProfiles.MappingConfig).Assembly);

builder.Services.AddScoped<AuthorizationService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddAuthorizationCore();

builder.Services.AddResponseCaching();

builder.Services.AddAntiforgery(x =>
{
    x.SuppressXFrameOptionsHeader = true;
});

if (builder.Environment.IsStaging() || builder.Environment.IsProduction())
{
    builder.WebHost.UseStaticWebAssets();
}

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        if (ctx.File.Name == "blazor.web.js")
        {
            ctx.Context.Response.Headers["Cache-Control"] = "public, max-age=31536000";
        }
    }
});


app.UseResponseCaching();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRobotsMiddleware();


app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(NarForumUser.Client._Imports).Assembly);

app.MapDefaultEndpoints();

app.Run();
