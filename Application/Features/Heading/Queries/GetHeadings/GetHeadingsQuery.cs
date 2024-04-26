using MediatR;

namespace Application.Features.Heading.Queries.GetHeadings
{
    public class GetHeadingsQuery : IRequest<List<HeadingDTO>>
    {
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }

    }
}
