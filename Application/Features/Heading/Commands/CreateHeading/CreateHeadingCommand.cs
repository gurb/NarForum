using Application.Models;
using MediatR;

namespace Application.Features.Heading.Commands.CreateHeading
{
    public class CreateHeadingCommand : IRequest<ApiResponse>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string? Content { get; set; }
    }
}
