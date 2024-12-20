﻿using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Category: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
		[ForeignKey("ParentCategoryId")]
		public Category? ParentCategory { get; set; }
        public Guid? ParentCategoryId { get; set; }
		[ForeignKey("SectionId")]
		public Section? Section { get; set; }
        public Guid? SectionId { get; set; }
        public int OrderIndex { get; set; }

        public int HeadingCounter { get; set; }
        public int PostCounter { get; set; }

        public Guid? LastHeadingId { get; set; }
        public Guid? LastPostId { get; set; }
        public string? LastUserName { get; set; }
        public Guid? LastUserId { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
