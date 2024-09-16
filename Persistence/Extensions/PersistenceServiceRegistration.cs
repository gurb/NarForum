using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Repositories;

namespace Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ForumDbContext>(options =>
                {
                    //options.UseSqlServer(configuration.GetConnectionString("ForumDatabaseConnectionString"));
                    options.UseNpgsql(configuration.GetConnectionString("ForumDatabaseConnectionString"));
                }
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IHeadingRepository, HeadingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IReplyRepository, ReplyRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();

            services.AddScoped<IForumStatService, ForumStatService>();
            services.AddScoped<ITrackingLogRepository, TrackingLogRepository>();

            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IBlogCommentRepository, BlogCommentRepository>();
            services.AddScoped<IBlogCategoryRepository, BlogCatergoryRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<ILogoService, LogoService>();

            return services;
        }
    }
}
