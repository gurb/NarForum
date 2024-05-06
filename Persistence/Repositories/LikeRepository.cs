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
    public class LikeRepository : ILikeRepository
    {
        protected readonly ForumDbContext _context;

        public LikeRepository(ForumDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Like Entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Like>> GetAllAsync(Expression<Func<Like, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
