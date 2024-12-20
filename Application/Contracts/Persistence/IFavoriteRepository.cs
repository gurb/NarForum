﻿using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IFavoriteRepository
    {
        Task AddAsync(Favorite Entity);
        Task DeleteAsync(Favorite Entity);
        Task UpdateAsync(Favorite Entity);
        Task<List<Favorite>> GetAllAsync(Expression<Func<Favorite, bool>> predicate);
        Task<Favorite?> GetAsync(Expression<Func<Favorite, bool>> predicate);
        int GetCount(Expression<Func<Favorite, bool>> predicate);
        Task<List<Favorite>> GetFavoritesWithPagination(Expression<Func<Favorite, bool>> predicate, int pageIndex, int pageSize);
    }
}
