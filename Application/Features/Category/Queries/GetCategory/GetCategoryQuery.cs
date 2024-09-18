using Application.Features.Category.Queries.GetCategories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryDTO>
    {
        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
    }
}
