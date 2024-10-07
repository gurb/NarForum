using AutoMapper;
using NarForumAdmin.Models;
using NarForumAdmin.Models.TrackingLog;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using NarForumAdmin.Contracts;

namespace NarForumAdmin.Services
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
            
            try
            {
                var addTrackingLogCommand = _mapper.Map<AddTrackingLogCommand>(command);
                var data = await _client.AddTrackingLogAsync(addTrackingLogCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<TrackingLogVM> GetTrackingLog(GetTrackingLogQueryVM request)
        {
            
            try
            {
                var query = _mapper.Map<GetTrackingLogQuery>(request);
                var data = await _client.GetTrackingLogAsync(query);

                return _mapper.Map<TrackingLogVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<TrackingLogVM>> GetTrackingLogs(GetTrackingLogsQueryVM request)
        {
            try
            {
                var query = _mapper.Map<GetTrackingLogsQuery>(request);
                var data = await _client.GetTrackingLogsAsync(query);

                return _mapper.Map<List<TrackingLogVM>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<TrackingLogsPaginationVM> GetTrackingLogsWithPagination(GetTrackingLogsWithPaginationQueryVM request)
        {
            
            try
            {
                var query = _mapper.Map<GetTrackingLogsWithPaginationQuery>(request);
                var data = await _client.GetTrackingLogsWithPaginationAsync(query);

                return _mapper.Map<TrackingLogsPaginationVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
