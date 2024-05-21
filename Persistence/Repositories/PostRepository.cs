using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ForumDbContext context) : base(context)
        {
            
        }

        public async Task<Post?> GetLastPost(int? headingId)
        {
            return await _context.Posts.AsNoTracking().Where(x => x.HeadingId == headingId).OrderBy(x => x.Id).LastOrDefaultAsync();
        }

        public async Task<List<Post>> GetPostsByHeadingId(int headingId)
        {
            return await _context.Posts.AsNoTracking().Where(x => x.HeadingId == headingId).ToListAsync();
        }

        public async Task<List<Post>> GetPostsByHeadingIdWithPagination(int headingId, int pageIndex, int pageSize)
        {
            var totalCount = _context.Posts.AsNoTracking().Count();

            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var productsPerPage = await _context.Posts.AsNoTracking()
                .Where(x => x.HeadingId == headingId)
                .Skip((pageIndex-1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return productsPerPage;
        }

        public async Task<List<Post>> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize)
        {
            var totalCount = _context.Posts.AsNoTracking().Count();

            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var productsPerPage = await _context.Posts.AsNoTracking()
                .Where(x => x.UserName == userName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return productsPerPage;
        }

        public int GetPostsCount(Expression<Func<Post, bool>> predicate)
        {
            return _context.Posts.AsNoTracking().Where(predicate).Count();
        }

        public int GetPostsCountByHeadingId(int headingId)
        {
            return  _context.Posts.AsNoTracking().Where(x => x.HeadingId == headingId).Count();
        }

        public int GetPostsCountByUserName(string userName)
        {
            return _context.Posts.AsNoTracking().Where(x => x.UserName == userName).Count();
        }


        public async Task<List<Post>> GetPostsWithPagination(Expression<Func<Post, bool>> predicate, int pageIndex, int pageSize)
        {
            var totalCount = _context.Posts.AsNoTracking().Count();

            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var productsPerPage = await _context.Posts.AsNoTracking()
                .Where(predicate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return productsPerPage;
        }
    }
}
