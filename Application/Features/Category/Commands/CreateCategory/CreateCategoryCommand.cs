using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<string>
    {
        public string Name { get; set; } = string.Empty;
        public string? SectionId { get; set; }
        public string? ParentCategoryId { get; set; }
    }
}
