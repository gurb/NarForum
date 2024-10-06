namespace Application.Models.Identity;

public class AuthRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsAdminPanel { get; set; }
}
