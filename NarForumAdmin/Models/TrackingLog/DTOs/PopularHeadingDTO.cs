﻿namespace NarForumAdmin.Models.TrackingLog.DTOs
{
    public class PopularHeadingDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? URL { get; set; }
        public int ViewCounter { get; set; }
        public DateTime DateTime { get; set; }
    }
}
