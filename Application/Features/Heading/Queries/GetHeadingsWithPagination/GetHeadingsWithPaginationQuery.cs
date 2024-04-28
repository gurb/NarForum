using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Queries.GetHeadingsWithPagination
{
    public class GetHeadingsWithPaginationQuery :  IRequest<HeadingsPaginationDTO>
    {
        public string? CategoryName { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
