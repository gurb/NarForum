using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence;

public interface IBlogCategoryRepository
{
    Task AddAsync(BlogCategory Entity);
    Task<bool> AnyAsync(Expression<Func<BlogCategory, bool>> predicate);
    Task DeleteAsync(BlogCategory Entity);
    Task UpdateAsync(BlogCategory Entity);
    Task<BlogCategory> GetAsync(Expression<Func<BlogCategory, bool>> predicate);
    Task<List<BlogCategory>> GetAllAsync(Expression<Func<BlogCategory, bool>> predicate);
}
