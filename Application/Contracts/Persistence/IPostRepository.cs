using Domain;

namespace Application.Contracts.Persistence
{
    public interface IPostRepository : IGenericRepository<Post> 
    { 
        Task<List<Post>> GetPostsByHeadingId(int headingId);

    }
}
