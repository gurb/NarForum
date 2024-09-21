﻿using AdminUI.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace AdminUI.Models.Image
{
    public class UploadImageRequestVM
    {
        public UploadImageTypeVM Type { get; set; }
        public List<IFormFile>? Files { get; set; }
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? BlogPostId { get; set; }
        public Guid? StaticPageId { get; set; }
        public string? Dir { get; set; }
    }
}