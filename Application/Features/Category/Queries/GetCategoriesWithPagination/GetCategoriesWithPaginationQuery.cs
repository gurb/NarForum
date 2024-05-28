using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetCategoriesWithPagination
{
    public class GetCategoriesWithPaginationQuery : IRequest<CategoriesPaginationDTO>
    {
        public string? Name { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
