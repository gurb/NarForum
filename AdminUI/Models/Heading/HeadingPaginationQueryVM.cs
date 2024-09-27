using AdminUI.Models.Enums;

namespace AdminUI.Models.Heading
{
    public class HeadingPaginationQueryVM
    {
        public string? UserName { get; set; }
        public string? CategoryName { get; set; }
        public SortTypeVM SortType { get; set; } = SortTypeVM.RECENT;
        public string? SearchTitle { get; set; }
        public string? SearchUser { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsComponent { get; set; }
        public Guid? CategoryId { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
