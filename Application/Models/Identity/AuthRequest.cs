﻿namespace Application.Models.Identity;

public class AuthRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTimeOffset DateTime { get; set; }
}
