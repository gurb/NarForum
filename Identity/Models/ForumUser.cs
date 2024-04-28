using Microsoft.AspNetCore.Identity;

namespace Identity.Models;

public class ForumUser: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastOnlineTime { get; set; }
    public string? Description { get; set; }
}
