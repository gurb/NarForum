using MediatR;

namespace Application.Features.Report.Queries.GetReport
{
    public class GetReportQuery:  IRequest<ReportDTO>
    {
        public Guid? Id { get; set; }
    }
}
