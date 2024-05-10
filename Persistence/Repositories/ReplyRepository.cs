using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class ReplyRepository : GenericRepository<Reply>, IReplyRepository
    {
        public ReplyRepository(ForumDbContext context) : base(context)
        {

        }
    }
}
