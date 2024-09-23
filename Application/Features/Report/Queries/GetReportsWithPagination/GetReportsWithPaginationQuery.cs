using MediatR;


namespace Application.Features.Report.Queries.GetReportsWithPagination
{
    public class GetReportsWithPaginationQuery :  IRequest<ReportsPaginationDTO>
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Guid? SenderUserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? HeadingId { get; set; }

        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
