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
        public int CategoryId { get; set; }
		public string Name { get; set; } = string.Empty;
        public string UrlName { get; set; } = string.Empty;
        public int UrlIndex { get; set; }
        public Guid? SectionId { get; set; }
		public Guid? ParentCategoryId { get; set; }

		public int HeadingCounter { get; set; }
        public int PostCounter { get; set; }

        public Guid? LastHeadingId { get; set; }
		public Guid? LastPostId { get; set; }

        public string? LastCategoryTitle { get; set; }
        public int? LastCategoryId { get; set; }
		public string? LastHeadingTitle { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
