using Application.Models;
using MediatR;

namespace Application.Features.Heading.Commands.UpdateHeading
{
    public class UpdateHeadingCommand : IRequest<ApiResponse>
    {

        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
