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
    public class FavoriteRepository : IFavoriteRepository
    {
        protected readonly ForumDbContext _context;

        public FavoriteRepository(ForumDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Favorite Entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Favorite>> GetAllAsync(Expression<Func<Favorite, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
