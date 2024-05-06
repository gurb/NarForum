using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IFavoriteRepository
    {
        Task AddAsync(Favorite Entity);
        Task<List<Favorite>> GetAllAsync(Expression<Func<Favorite, bool>> predicate);
    }
}
