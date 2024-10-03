using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Handlers;
using GurbForumUser.Client.Pages;
using GurbForumUser.Client.Providers;
using GurbForumUser.Client.Services;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;
using GurbForumUser.Client.Services.UI;
using GurbForumUser.Components;
using GurbForumUser.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using System.Reflection;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<JwtAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:44342")).AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

//builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<RefreshStateService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
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
builder.Services.AddScoped<ISmtpSettingsService, SmtpSettingsService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

builder.Services.AddAutoMapper(typeof(GurbForumUser.Client.MappingProfiles.MappingConfig).Assembly);

builder.Services.AddScoped<AuthorizationService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddAuthorizationCore();


builder.Services.AddScoped<AuthenticationStateProvider, PrerenderedAuthenticationStateProvider>();





var app = builder.Build();

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

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GurbForumUser.Client._Imports).Assembly);

app.Run();
