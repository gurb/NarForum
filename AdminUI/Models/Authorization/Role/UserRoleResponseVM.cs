﻿namespace AdminUI.Models.Authentication.Role;

public class UserRoleResponseVM
{
    public string Id { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? NormalizedName { get; set; }
}