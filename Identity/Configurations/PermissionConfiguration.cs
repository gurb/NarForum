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
                // role member permissions
                new Permission { Id = "dc9aff7b-7de7-4ef3-90a1-047f8ef935f4", Name = "FORUM_PROFILE_PAGE", IsGranted = true, RoleId= "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },
                new Permission { Id = "9519adb7-9611-40bc-bd8e-2d71b5097755", Name = "FORUM_CAN_OPEN_HEADING", IsGranted = true, RoleId = "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },
                new Permission { Id = "b426d1e0-4afe-4752-abb1-444f593ca9d3", Name = "FORUM_CAN_REPLY", IsGranted = true, RoleId = "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },

                // role moderator permissions
                new Permission { Id = "a0737557-3282-45eb-b8ed-daa1cc2bc924", Name = "FORUM_PROFILE_PAGE", IsGranted = true, RoleId = "bac43a5e-f7bb-4448-b12f-1add431ccbbf" },
                new Permission { Id = "0c125c40-7d4e-41de-a00f-c9748142d35a", Name = "FORUM_CAN_OPEN_HEADING", IsGranted = true, RoleId = "bac43a5e-f7bb-4448-b12f-1add431ccbbf" },
                new Permission { Id = "f46684f5-6513-4a7d-bbdd-0e43a395a38c", Name = "FORUM_CAN_REPLY", IsGranted = true, RoleId = "bac43a5e-f7bb-4448-b12f-1add431ccbbf" },

                // role admin permissions
                new Permission { Id = "532be471-dd63-4a39-ba2a-4fdc31dc432b", Name = "FORUM_PROFILE_PAGE", IsGranted = true, RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" },
                new Permission { Id = "25315678-0f4a-4a38-b82c-83a130ac4992", Name = "FORUM_CAN_OPEN_HEADING", IsGranted = true, RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" },
                new Permission { Id = "e87f7d83-721e-4e3d-84c4-9b7f48215a84", Name = "FORUM_CAN_REPLY", IsGranted = true, RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" }
            );
        }
    }
}
