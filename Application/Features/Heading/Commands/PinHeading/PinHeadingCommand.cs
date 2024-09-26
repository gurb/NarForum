using Application.Models;
using MediatR;

namespace Application.Features.Heading.Commands.PinHeading
{
    public class PinHeadingCommand : IRequest<ApiResponse>
    {
        public Guid? Id { get; set; }
    }
}
