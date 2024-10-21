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
                new Permission { Id = "0e6f1e30-aaa1-49d3-8918-419291f9eebe", DisplayName="Admin", Name = "ADMIN", IsGranted = true, RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", ParentPermissionId=null, PermissionDefinitionId="87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new Permission { Id = "d4cc9401-ca88-4de3-941d-c5b2c1b960f4", DisplayName="Authorization", Name = "ADMIN_AUTHORIZATION", IsGranted = true, RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", ParentPermissionId = "0e6f1e30-aaa1-49d3-8918-419291f9eebe", PermissionDefinitionId = "ba8b1242-49b5-4706-b641-e07d23b78884" },
                new Permission { Id = "0dd2e45e-0362-4672-a475-1e0b9912d130", DisplayName = "Permission", Name = "ADMIN_AUTHORIZATION_PERMISSION", IsGranted = true, RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", ParentPermissionId= "d4cc9401-ca88-4de3-941d-c5b2c1b960f4", PermissionDefinitionId = "5d3da4f1-95a7-4fc4-abac-df5f782f1e79" }
            );
            builder.HasData(
                new Permission { Id = "8fbbd082-aa86-4383-998c-c638d48164d1", DisplayName = "Change Permission Status", Name = "ADMIN_AUTHORIZATION_PERMISSION_STATUS_CHANGE", IsGranted = true, RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", ParentPermissionId = "0dd2e45e-0362-4672-a475-1e0b9912d130", PermissionDefinitionId = "8347ac9a-2b9a-4b03-9cb5-3855adc46355" }
            );
        }
    }
}
