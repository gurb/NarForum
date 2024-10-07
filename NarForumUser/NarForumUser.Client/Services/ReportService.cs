using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models;
using NarForumUser.Client.Models.Report;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

namespace NarForumUser.Client.Services
{
    public class ReportService : BaseHttpService, IReportService
    {
        private readonly IMapper _mapper;

        public ReportService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> CreateReport(CreateReportCommandVM command)
        {
            var createReportCommand = _mapper.Map<CreateReportCommand>(command);
            var data = await _client.CreateReportAsync(createReportCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ReportVM> GetReport(GetReportQueryVM request)
        {
            var query = _mapper.Map<GetReportQuery>(request);
            var data = await _client.GetReportAsync(query);

            return _mapper.Map<ReportVM>(data);
        }

        public async Task<List<ReportVM>> GetReports(GetReportsQueryVM request)
        {
            var query = _mapper.Map<GetReportsQuery>(request);
            var data = await _client.ReportsAsync(query);

            return _mapper.Map<List<ReportVM>>(data);
        }

        public async Task<ReportsPaginationVM> GetReportsWithPagination(GetReportsWithPaginationQueryVM request)
        {
            GetReportsWithPaginationQuery query = _mapper.Map<GetReportsWithPaginationQuery>(request);

            var reportsPagination = await _client.GetReportsWithPaginationAsync(query);

            var data = _mapper.Map<ReportsPaginationVM>(reportsPagination);

            return data;
        }

        public async Task<ApiResponseVM> RemoveReport(RemoveReportCommandVM command)
        {
            var removeReportCommand = _mapper.Map<RemoveReportCommand>(command);
            var data = await _client.RemoveReportAsync(removeReportCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
