using Application.Models;
using MediatR;


namespace Application.Features.Heading.Commands.LockHeading
{
    public class LockHeadingCommand : IRequest<ApiResponse>
    {
        public Guid? Id { get; set; }
    }
}
