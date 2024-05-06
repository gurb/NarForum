using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetCategories
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? SectionId { get; set; }
        public int? ParentCategoryId { get; set; }

        public int HeadingCounter { get; set; }
        public int PostCounter { get; set; }

        public int? LastHeadingId { get; set; }
        public int? LastPostId { get; set; }
        public string? LastHeadingTitle { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
