using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Logo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Base64 { get; set; }
        public string? Text { get; set; }
        public string? AltText { get; set; }
        public string? Path { get; set; }
    }
}
