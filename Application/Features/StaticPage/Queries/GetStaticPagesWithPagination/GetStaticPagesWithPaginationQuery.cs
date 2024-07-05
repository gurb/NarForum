using MediatR;

namespace Application.Features.StaticPage.Queries.GetStaticPagesWithPagination;

public class GetStaticPagesWithPaginationQuery : IRequest<StaticPagesPaginationDTO>
{
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
