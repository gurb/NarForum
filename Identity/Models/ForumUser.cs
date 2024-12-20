﻿using Microsoft.AspNetCore.Identity;

namespace Identity.Models;

public class ForumUser: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    public DateTime LastOnlineTime { get; set; }
    public string? Description { get; set; }
    public bool IsBlocked { get; set; }
    public string? Role { get; set; }
    public string? Rank { get; set; }
    public int PostCounter { get; set; }
    public int HeadingCounter { get; set; }
}
