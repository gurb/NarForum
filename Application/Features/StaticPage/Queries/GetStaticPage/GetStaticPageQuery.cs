using Application.Features.StaticPage.Queries.GetStaticPages;
using MediatR;

namespace Application.Features.StaticPage.Queries.GetStaticPage;

public class GetStaticPageQuery: IRequest<StaticPageDTO>
{
    public Guid Id { get; set; } = Guid.Empty;
}
