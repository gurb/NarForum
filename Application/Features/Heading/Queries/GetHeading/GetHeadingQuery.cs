using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Queries.GetHeading
{
    public class GetHeadingQuery : IRequest<HeadingDTO>
    {
        public string? HeadingId { get; set; }
    }
}
