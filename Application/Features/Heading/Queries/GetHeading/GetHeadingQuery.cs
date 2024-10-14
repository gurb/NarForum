using MediatR;

namespace Application.Features.Heading.Queries.GetHeading
{
    public class GetHeadingQuery : IRequest<HeadingDTO>
    {
        public Guid HeadingId { get; set; }
    }
}
