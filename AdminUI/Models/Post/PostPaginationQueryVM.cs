﻿namespace AdminUI.Models.Post
{
    public class PostPaginationQueryVM
    {
        public string? UserName { get; set; }
        public int? HeadingId { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}