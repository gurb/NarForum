using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class QuoteRepository : GenericRepository<Quote>, IQuoteRepository
    {
        public QuoteRepository(ForumDbContext context) : base(context)
        {

        }
    }
}
