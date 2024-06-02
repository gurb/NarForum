using MediatR;

namespace Application.Features.Heading.Commands.RemoveHeading
{

    public class RemoveHeadingCommand : IRequest<int>
    {
        public int? HeadingId { get; set; }
    }
}
