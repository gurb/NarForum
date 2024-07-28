using Application.Contracts.Identity;
using Application.Models.Identity;
using Identity.DatabaseContext;
using Identity.Models;
using Identity.Models.DTO;
using Identity.Services;
using Identity.Services.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Identity.Extensions
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            //services.AddDbContext<ForumIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ForumIdentityDatabaseConnectionString")));
            services.AddDbContext<ForumIdentityDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ForumIdentityDatabaseConnectionString")));
            

            services.AddIdentity<ForumUser, IdentityRole>()
                .AddEntityFrameworkStores<ForumIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddScoped<IMessageService, MessageService>();


            services.Configure<GarnetConfiguration>(configuration.GetSection("Garnet"));
            services.AddSingleton<IGarnetCacheService, GarnetCacheService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.SaveToken = true;

                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };

                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && 
                            (
                                path.StartsWithSegments("/track") || 
                                path.StartsWithSegments("/chat")
                            ))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddHostedService<TrackBackgroundService>();
            services.AddHostedService<ChatBackgroundService>();


            return services;
        }
    }
}
