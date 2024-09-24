using BlazorUI.Models;
using BlazorUI.Models.Report;

namespace BlazorUI.Contracts
{
    public interface IReportService
    {
        Task<List<ReportVM>> GetReports(GetReportsQueryVM request);
        Task<ReportVM> GetReport(GetReportQueryVM request);
        Task<ReportsPaginationVM> GetReportsWithPagination(GetReportsWithPaginationQueryVM request);
        Task<ApiResponseVM> CreateReport(CreateReportCommandVM command);
        Task<ApiResponseVM> RemoveReport(RemoveReportCommandVM command);
    }
}
