using MediatR;

namespace Application.Features.Heading.Queries.GetHeadings
{
    public class GetHeadingsQuery : IRequest<List<HeadingDTO>>
    {
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }

    }
}
