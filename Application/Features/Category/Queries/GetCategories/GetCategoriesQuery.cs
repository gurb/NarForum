using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDTO>>
    {
        public Guid? ParentCategoryId { get; set; }

        public string? CategoryName { get; set; }

        public bool? IsOnlySection { get; set; }
    }
}
