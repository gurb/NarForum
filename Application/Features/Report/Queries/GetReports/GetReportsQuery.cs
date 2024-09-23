using Application.Features.Report.Queries.GetReport;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Report.Queries.GetReports
{
    public class GetReportsQuery: IRequest<List<ReportDTO>>
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Guid? SenderUserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? HeadingId { get; set; }
    }
}
