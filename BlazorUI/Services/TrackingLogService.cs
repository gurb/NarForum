using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models;
using BlazorUI.Models.TrackingLog;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
{
    public class TrackingLogService : BaseHttpService, ITrackingLogService
    {
        private readonly IMapper _mapper;
        public TrackingLogService(IClient client, LocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> AddTrackingLog(AddTrackingLogCommandVM command)
        {
            var addTrackingLogCommand = _mapper.Map<AddTrackingLogCommand>(command);
            var data = await _client.AddTrackingLogAsync(addTrackingLogCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<TrackingLogVM> GetTrackingLog(GetTrackingLogQueryVM request)
        {
            var query = _mapper.Map<GetTrackingLogQuery>(request);
            var data = await _client.GetTrackingLogAsync(query);

            return _mapper.Map<TrackingLogVM>(data);
        }

        public async Task<List<TrackingLogVM>> GetTrackingLogs(GetTrackingLogsQueryVM request)
        {
            var query = _mapper.Map<GetTrackingLogsQuery>(request);
            var data = await _client.GetTrackingLogsAsync(query);

            return _mapper.Map<List<TrackingLogVM>>(data);
        }
    }
}
