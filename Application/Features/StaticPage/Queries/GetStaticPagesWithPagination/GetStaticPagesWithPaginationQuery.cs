using MediatR;

namespace Application.Features.StaticPage.Queries.GetStaticPagesWithPagination;

public class GetStaticPagesWithPaginationQuery : IRequest<StaticPagesPaginationDTO>
{
    public string? SearchTitle { get; set; }

    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
