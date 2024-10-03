namespace GurbForumUser.Middleware
{
    public class RobotsMiddleware
    {
        private readonly RequestDelegate _next;

        public RobotsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/robots.txt"))
            {
                context.Response.ContentType = "text/plain";
                await context.Response.SendFileAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "robots.txt"));
            }
            else
            {
                await _next(context);
            }
        }
    }
}
