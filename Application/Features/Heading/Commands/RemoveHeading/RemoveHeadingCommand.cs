using MediatR;

namespace Application.Features.Heading.Commands.RemoveHeading
{

    public class RemoveHeadingCommand : IRequest<string>
    {
        public string? HeadingId { get; set; }
    }
}
