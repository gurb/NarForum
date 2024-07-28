using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetCategories
{
    public class CategoryDTO
    {
        public Guid Id { get; set; } = Guid.Empty;
		public string Name { get; set; } = string.Empty;
        public Guid SectionId { get; set; } = Guid.Empty;
		public Guid ParentCategoryId { get; set; } = Guid.Empty;

		public int HeadingCounter { get; set; }
        public int PostCounter { get; set; }

        public Guid LastHeadingId { get; set; } = Guid.Empty;
		public Guid LastPostId { get; set; } = Guid.Empty;
		public string? LastHeadingTitle { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
