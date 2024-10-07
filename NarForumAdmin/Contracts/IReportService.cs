using NarForumAdmin.Models;
using NarForumAdmin.Models.Report;

namespace NarForumAdmin.Contracts
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
