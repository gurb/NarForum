using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Commands.CreateHeading
{
    public class CreateHeadingCommand : IRequest<int>
    {
        public string? Title { get; set; }
        public int? CategoryId { get; set; }
        public string? Content { get; set; }
    }
}
