using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class HeadingRepository : GenericRepository<Heading>, IHeadingRepository
    {
        public HeadingRepository(ForumDbContext context) : base(context)
        {

        }
    }
}
