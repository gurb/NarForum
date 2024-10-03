using GurbForumUser.Middleware;

namespace GurbForumUser.Extensions
{
    public static class RobotsMiddlewareExtensions
    {
        public static IApplicationBuilder UseRobotsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RobotsMiddleware>();
        }
    }
}
