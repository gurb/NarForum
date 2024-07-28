using MediatR;

namespace Application.Features.Heading.Commands.RemoveHeading
{

    public class RemoveHeadingCommand : IRequest<Guid>
    {
        public Guid HeadingId { get; set; }
    }
}
