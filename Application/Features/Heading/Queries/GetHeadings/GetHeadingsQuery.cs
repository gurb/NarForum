using MediatR;

namespace Application.Features.Heading.Queries.GetHeadings
{
    public class GetHeadingsQuery : IRequest<List<HeadingDTO>>
    {
    }
}
