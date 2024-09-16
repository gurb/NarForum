﻿using BlazorUI.Models.Enums;

namespace BlazorUI.Models.Heading
{
    public class GetHeadingsWithPaginationQueryVM
    {
        public string? UserName { get; set; }
        public string? CategoryName { get; set; }
        public SortTypeVM SortType { get; set; } = SortTypeVM.RECENT;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? SearchTitle { get; set; }
        public string? SearchUser { get; set; }

        public Guid? CategoryId { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}