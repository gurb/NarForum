using NarForumAdmin;
using NarForumAdmin.Contracts;
using NarForumAdmin.Handlers;
using NarForumAdmin.Providers;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using NarForumAdmin.Services.UI;
using NarForumAdmin.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var assembly = Assembly.GetExecutingAssembly();
builder.Services.AddAutoMapper(assembly);

builder.Services.AddLogging(logging =>
{
    logging.SetMinimumLevel(LogLevel.Debug);
});


builder.Services.AddTransient<JwtAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(
    client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseUrl")!)).AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

//builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<RefreshStateService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IHeadingService, HeadingService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IForumStatService, ForumStatService>();

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

builder.Services.AddSingleton<AlertService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var host = builder.Build();

AppDomain.CurrentDomain.UnhandledException += (sender, errorArgs) =>
{
    var exception = (Exception)errorArgs.ExceptionObject;
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(exception, "Error got: {Message}", exception.Message);
};


await host.RunAsync();
