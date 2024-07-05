using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BlogCatergoryRepository : IBlogCategoryRepository
    {

        protected readonly ForumDbContext _context;

        public BlogCatergoryRepository(ForumDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(BlogCategory Entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(BlogCategory Entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<BlogCategory>> GetAllAsync(Expression<Func<BlogCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<BlogCategory> GetAsync(Expression<Func<BlogCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BlogCategory Entity)
        {
            throw new NotImplementedException();
        }
    }
}
