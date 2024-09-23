using Application.Features.Report.Queries.GetReport;


namespace Application.Features.Report.Queries.GetReportsWithPagination
{
    public class ReportsPaginationDTO
    {
        public List<ReportDTO>? Reports { get; set; }
        public int TotalCount { get; set; }
    }
}
