﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Models;

namespace Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ForumUser>
{
    public void Configure(EntityTypeBuilder<ForumUser> builder)
    {
        var hasher = new PasswordHasher<ForumUser>();
        builder.HasData(
             new ForumUser
             {
                 Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "Admin",
                 UserName = "admin",
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 Role="Administrator",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ForumUser
             {
                 Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                 Email = "user@localhost.com",
                 NormalizedEmail = "USER@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "User",
                 UserName = "user",
                 NormalizedUserName = "USER@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ForumUser
             {
                 Id = "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                 Email = "moderator@localhost.com",
                 NormalizedEmail = "MODERATOR@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "Moderator",
                 UserName = "moderator",
                 NormalizedUserName = "MODERATOR@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             }
        );
    }
}
