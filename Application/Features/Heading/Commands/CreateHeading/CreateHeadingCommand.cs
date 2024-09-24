using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Commands.CreateHeading
{
    public class CreateHeadingCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string? Content { get; set; }
    }
}
