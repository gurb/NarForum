using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository 
    {
        public PostRepository(ForumDbContext context) : base(context)
        {
            
        }

        public async Task<List<Post>> GetPostsByHeadingId(int headingId)
        {
            return await _context.Posts.AsNoTracking().Where(x => x.HeadingId == headingId).ToListAsync();
        }
    }
}
