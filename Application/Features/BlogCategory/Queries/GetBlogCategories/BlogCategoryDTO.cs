using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogCategory.Queries.GetBlogCategories
{
    public class BlogCategoryDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
