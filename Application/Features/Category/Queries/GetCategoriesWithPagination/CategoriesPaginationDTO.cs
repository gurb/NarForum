using Application.Features.Category.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetCategoriesWithPagination
{
    public class CategoriesPaginationDTO
    {
        public List<CategoryDTO>? Categories { get; set; }
        public int TotalCount { get; set; }
    }
}
