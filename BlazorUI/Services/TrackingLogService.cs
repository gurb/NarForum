using BlazorUI.Contracts;
using BlazorUI.Models;
using BlazorUI.Models.TrackingLog;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
{
    public class TrackingLogService : BaseHttpService, ITrackingLogService
    {
        public TrackingLogService(IClient client, LocalStorageService localStorage) : base(client, localStorage)
        {
        }

        public Task<ApiResponseVM> AddBlogCategory(AddTrackingLogCommandVM command)
        {
            throw new NotImplementedException();
        }

        public Task<List<TrackingLogVM>> GetBlogCategories(GetTrackingLogsQueryVM request)
        {
            throw new NotImplementedException();
        }

        public Task<TrackingLogVM> GetBlogCategory(GetTrackingLogQueryVM request)
        {
            throw new NotImplementedException();
        }
    }
}
