using AdminUI.Models;
using AdminUI.Models.TrackingLog;

namespace AdminUI.Contracts
{
    public interface ITrackingLogService
    {
        Task<List<TrackingLogVM>> GetTrackingLogs(GetTrackingLogsQueryVM request);
        Task<TrackingLogsPaginationVM> GetTrackingLogsWithPagination(GetTrackingLogsWithPaginationQueryVM request);
        Task<TrackingLogVM> GetTrackingLog(GetTrackingLogQueryVM request);
        Task<ApiResponseVM> AddTrackingLog(AddTrackingLogCommandVM command);
    }
}
