using Application.Features.Section.Queries.GetSections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Section.Queries.GetSectionsWithPagination
{
    public class SectionsPaginationDTO
    {
        public List<SectionDTO>? Sections { get; set; }
        public int TotalCount { get; set; }
    }
}
