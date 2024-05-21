using Application.Features.Category.Queries.GetCategoriesWithPagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Section.Queries.GetSectionsWithPagination
{
   
    public class GetSectionsWithPaginationQuery : IRequest<SectionsPaginationDTO>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
