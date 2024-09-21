using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UploadFile
    {
        [Key]
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public string? ContentType { get; set; }
        public string? UserName { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    }
}
