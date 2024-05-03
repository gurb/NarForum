﻿using System;
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
    }
}
