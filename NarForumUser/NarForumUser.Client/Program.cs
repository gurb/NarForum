using NarForumUser.Client.Contracts;
using NarForumUser.Client.Handlers;
using NarForumUser.Client.Providers;
using NarForumUser.Client.Services;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;
using NarForumUser.Client.Services.UI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<JwtAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseUrl")!)).AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

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

builder.Services.AddSingleton<ToastService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<AuthorizationService>();


await builder.Build().RunAsync();
