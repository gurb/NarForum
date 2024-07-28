using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "dac42a6e-f7bb-4448-b3cf-1add431ccbbf",
                        UserId = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "bac43a5e-f7bb-4448-b12f-1add431ccbbf",
                        UserId = "076f24af-8934-4bf2-8d4e-03a5b48db4f4"
                    }
                    
                );
        }
    }

}
