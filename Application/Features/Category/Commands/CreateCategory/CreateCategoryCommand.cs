using Application.Models;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<ApiResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid SectionId { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
