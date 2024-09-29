using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class ConfirmRequest
    {
        [Key]
        public Guid? Id { get; set; } = Guid.NewGuid();

        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public string? Email { get; set; }
        public bool IsVerified { get; set; }
        public bool IsValid { get; set; } = true;
        public DateTime? DateCreate { get; set; } = DateTime.UtcNow;
    }
}
