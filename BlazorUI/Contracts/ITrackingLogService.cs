using BlazorUI.Models;
using BlazorUI.Models.TrackingLog;

namespace BlazorUI.Contracts
{
    public interface ITrackingLogService
    {
        Task<List<TrackingLogVM>> GetBlogCategories(GetTrackingLogsQueryVM request);
        Task<TrackingLogVM> GetBlogCategory(GetTrackingLogQueryVM request);
        Task<ApiResponseVM> AddBlogCategory(AddTrackingLogCommandVM command);
    }
}
