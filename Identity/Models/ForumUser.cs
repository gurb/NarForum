using Microsoft.AspNetCore.Identity;

namespace Identity.Models;

public class ForumUser: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
