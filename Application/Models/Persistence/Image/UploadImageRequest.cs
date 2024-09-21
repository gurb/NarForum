using Application.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Persistence.Image
{
    public class UploadImageRequest
    {
        public UploadImageType Type { get; set; }
        public List<IFormFile>? Files { get; set; }
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? BlogPostId { get; set; }
        public Guid? StaticPageId { get; set; }
        public string? Dir { get; set; }
    }
}
