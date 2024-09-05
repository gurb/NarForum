using AdminUI.Models;
using AdminUI.Models.TrackingLog;

namespace BlazorUI.Contracts
{
    public interface ITrackingLogService
    {
        Task<List<TrackingLogVM>> GetTrackingLogs(GetTrackingLogsQueryVM request);
        Task<TrackingLogVM> GetTrackingLog(GetTrackingLogQueryVM request);
        Task<ApiResponseVM> AddTrackingLog(AddTrackingLogCommandVM command);
    }
}
