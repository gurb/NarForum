using Application.Features.StaticPage.Queries.GetStaticPages;

namespace Application.Features.StaticPage.Queries.GetStaticPagesWithPagination;

public class StaticPagesPaginationDTO
{
    public List<StaticPageDTO>? StaticPages { get; set; }
    public int TotalCount { get; set; }
}
