using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity.Models;

namespace Identity.Configurations
{

    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(
                // role admin permissions
                new Permission { Id = "b66c8a39-775b-48f3-b954-e9868105a496", Name = "ADMIN_AUTHORIZATION_PERMISSION_STATUS_CHANGE", IsGranted = true, RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" }
            );
        }
    }
}
