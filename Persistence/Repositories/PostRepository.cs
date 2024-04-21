using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository 
    {
        public PostRepository(ForumDbContext context) : base(context)
        {
            
        }
    }
}
