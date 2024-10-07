using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Report;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
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
            try
            {
                var createReportCommand = _mapper.Map<CreateReportCommand>(command);
                var data = await _client.CreateReportAsync(createReportCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ReportVM> GetReport(GetReportQueryVM request)
        {
            try
            {
                var query = _mapper.Map<GetReportQuery>(request);
                var data = await _client.GetReportAsync(query);

                return _mapper.Map<ReportVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<ReportVM>> GetReports(GetReportsQueryVM request)
        {
            try
            {
                var query = _mapper.Map<GetReportsQuery>(request);
                var data = await _client.ReportsAsync(query);

                return _mapper.Map<List<ReportVM>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ReportsPaginationVM> GetReportsWithPagination(GetReportsWithPaginationQueryVM request)
        {
            try
            {
                GetReportsWithPaginationQuery query = _mapper.Map<GetReportsWithPaginationQuery>(request);

                var reportsPagination = await _client.GetReportsWithPaginationAsync(query);

                var data = _mapper.Map<ReportsPaginationVM>(reportsPagination);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> RemoveReport(RemoveReportCommandVM command)
        {
            try
            {
                var removeReportCommand = _mapper.Map<RemoveReportCommand>(command);
                var data = await _client.RemoveReportAsync(removeReportCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
