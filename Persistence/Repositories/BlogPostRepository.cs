using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(ForumDbContext context) : base(context)
        {

        }
    }
}
