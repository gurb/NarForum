using NarForumUser.Client.Models;
using NarForumUser.Client.Models.TrackingLog;

namespace NarForumUser.Client.Contracts
{
    public interface ITrackingLogService
    {
        Task<List<TrackingLogVM>> GetTrackingLogs(GetTrackingLogsQueryVM request);
        Task<TrackingLogVM> GetTrackingLog(GetTrackingLogQueryVM request);
        Task<ApiResponseVM> AddTrackingLog(AddTrackingLogCommandVM command);
    }
}
