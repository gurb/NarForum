using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface ILikeRepository
    {
        Task AddAsync(Like Entity);
        Task<List<Like>> GetAllAsync(Expression<Func<Like, bool>> predicate);
    }
}
