using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence;

public interface ITrackingLogRepository
{
    Task AddAsync(TrackingLog Entity);
    Task<bool> AnyAsync(Expression<Func<TrackingLog, bool>> predicate);
    Task DeleteAsync(TrackingLog Entity);
    Task UpdateAsync(TrackingLog Entity);
    Task<TrackingLog> GetAsync(Expression<Func<TrackingLog, bool>> predicate);
    Task<List<TrackingLog>> GetAllAsync(Expression<Func<TrackingLog, bool>> predicate);
}
