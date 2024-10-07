using NarForumUser.Middleware;

namespace NarForumUser.Extensions
{
    public static class RobotsMiddlewareExtensions
    {
        public static IApplicationBuilder UseRobotsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RobotsMiddleware>();
        }
    }
}
