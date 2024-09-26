using Application.Models.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Queries.GetHeadingsWithPagination
{
    public class GetHeadingsWithPaginationQuery :  IRequest<HeadingsPaginationDTO>
    {
        public string? UserName { get; set; }
        public string? CategoryName { get; set; }
        public SortType SortType { get; set; } = SortType.RECENT;
        public bool IsComponent { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? SearchTitle { get; set; }
        public string? SearchUser { get; set; }

        public Guid? CategoryId { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
