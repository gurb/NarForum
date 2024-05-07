using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface ILikeRepository
    {
        Task AddAsync(Like Entity);
        Task DeleteAsync(Like Entity);
        Task UpdateAsync (Like Entity);
        Task<Like> GetAsync(Expression<Func<Like, bool>> predicate);
        Task<List<Like>> GetAllAsync(Expression<Func<Like, bool>> predicate);
    }
}
