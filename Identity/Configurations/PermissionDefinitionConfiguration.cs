using Identity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Configurations
{
    
    public class PermissionDefinitionConfiguration : IEntityTypeConfiguration<PermissionDefinition>
    {
        public void Configure(EntityTypeBuilder<PermissionDefinition> builder)
        {
            builder.HasData(
                new PermissionDefinition { Id = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8", Name = "FORUM", DisplayName="Forum", ParentPermissionDefinitionId = null },
                new PermissionDefinition { Id = "87800b42-e5dc-41e1-845a-789c387a9c8c", Name = "ADMIN", DisplayName="Admin", ParentPermissionDefinitionId = null }
            );

            // FORUM children
            builder.HasData(
                new PermissionDefinition { Id = "efd0da20-755d-4dcb-a10f-617d84bc52aa", Name = "FORUM_POST", DisplayName="Post", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                new PermissionDefinition { Id = "336e4081-f40d-4e45-bcc5-adb0c04d016f", Name = "FORUM_HEADING", DisplayName = "Heading", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                new PermissionDefinition { Id = "d9687026-5c6b-44c8-a4cf-31a7f7ada844", Name = "FORUM_SECTION", DisplayName = "Section", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                new PermissionDefinition { Id = "1d42748d-3f19-4f1b-bde0-786a4a245f46", Name = "FORUM_CATEGORY", DisplayName = "Category", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                new PermissionDefinition { Id = "8fdcb439-e635-466f-ae81-d7b161fe9a80", Name = "FORUM_PROFILE", DisplayName = "Profile", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                new PermissionDefinition { Id = "433a025d-e09e-414c-8fa2-b3d8fc67ecbb", Name = "FORUM_MESSAGE", DisplayName = "Message", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" }
            );

            // FORUM_POST children
            builder.HasData(
                new PermissionDefinition { Id = "8c87ab42-975a-4016-92a8-ec8e34852fbf", Name = "FORUM_POST_CREATE", DisplayName = "Create Post", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                new PermissionDefinition { Id = "58b4d6c9-7db7-490b-b118-7fff4839fe69", Name = "FORUM_POST_UPDATE", DisplayName = "Update Post", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                new PermissionDefinition { Id = "edae4f5c-d414-4753-b20c-7f6d32b8ed23", Name = "FORUM_POST_DELETE", DisplayName = "Delete Post", ParentPermissionDefinitionId = "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" }
            );

            // FORUM_HEADING children
            builder.HasData(
                new PermissionDefinition { Id = "6d4df87c-cf17-4db4-90e1-590b68e07e50", Name = "FORUM_HEADING_CREATE", DisplayName = "Create Heading", ParentPermissionDefinitionId = "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                new PermissionDefinition { Id = "4b35a46b-0ee0-48f5-a44f-b1317c4e3af2", Name = "FORUM_HEADING_UPDATE", DisplayName = "Update Heading", ParentPermissionDefinitionId = "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                new PermissionDefinition { Id = "f3311407-5848-4682-98ae-3a02701f1211", Name = "FORUM_HEADING_DELETE", DisplayName = "Delete Heading", ParentPermissionDefinitionId = "336e4081-f40d-4e45-bcc5-adb0c04d016f" }
            );

            // FORUM_SECTION children
            builder.HasData(
                new PermissionDefinition { Id = "0121f80b-f006-4b98-98b6-72fd0d294a9c", Name = "FORUM_SECTION_CREATE", DisplayName = "Create Section", ParentPermissionDefinitionId = "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                new PermissionDefinition { Id = "5cdd6187-b295-4ea5-ab2f-18355dab03bc", Name = "FORUM_SECTION_UPDATE", DisplayName = "Update Section", ParentPermissionDefinitionId = "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                new PermissionDefinition { Id = "36f5b8ce-f602-4268-ac03-047a92f255d8", Name = "FORUM_SECTION_DELETE", DisplayName = "Delete Section", ParentPermissionDefinitionId = "d9687026-5c6b-44c8-a4cf-31a7f7ada844" }
            );

            // FORUM_CATEGORY children
            builder.HasData(
                new PermissionDefinition { Id = "32b3175a-dd42-4431-bca1-9ab430ae84df", Name = "FORUM_CATEGORY_CREATE", DisplayName = "Create Category", ParentPermissionDefinitionId = "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                new PermissionDefinition { Id = "72a2d85e-80f4-4bd4-abee-b98842122219", Name = "FORUM_CATEGORY_UPDATE", DisplayName = "Update Category", ParentPermissionDefinitionId = "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                new PermissionDefinition { Id = "f258398c-250e-4d24-8b5b-327b6354f447", Name = "FORUM_CATEGORY_DELETE", DisplayName = "Delete Category", ParentPermissionDefinitionId = "1d42748d-3f19-4f1b-bde0-786a4a245f46" }
            );

            // FORUM_PROFILE children
            builder.HasData(
                new PermissionDefinition { Id = "94466734-1998-4237-90c3-0b3473889dbd", Name = "FORUM_PROFILE_VIEW", DisplayName = "View Profile Page", ParentPermissionDefinitionId = "8fdcb439-e635-466f-ae81-d7b161fe9a80" }
            );

            // FORUM_MESSAGE children
            builder.HasData(
                new PermissionDefinition { Id = "03508f20-5c3c-4167-9f41-d8cee9c35620", Name = "FORUM_MESSAGE_SEND", DisplayName = "Send Message", ParentPermissionDefinitionId = "433a025d-e09e-414c-8fa2-b3d8fc67ecbb" }
            );


            // ADMIN children
            builder.HasData(
                new PermissionDefinition { Id = "6d807b00-447b-4e7f-8255-99912e4024e4", Name = "ADMIN_POST", DisplayName = "Post", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e", Name = "ADMIN_HEADING", DisplayName = "Heading", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "f25163b7-43e5-4eba-bccb-95f8d2454f0a", Name = "ADMIN_SECTION", DisplayName = "Section", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4", Name = "ADMIN_CATEGORY", DisplayName = "Category", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" }
            );

            // ADMIN_POST children
            builder.HasData(
                new PermissionDefinition { Id = "aa55c85d-33ad-45ee-9dff-6d78aaf86a9c", Name = "ADMIN_POST_CREATE", DisplayName = "Create Post", ParentPermissionDefinitionId = "6d807b00-447b-4e7f-8255-99912e4024e4" },
                new PermissionDefinition { Id = "69860332-d98b-45c5-b3df-0a3ea6d02bda", Name = "ADMIN_POST_UPDATE", DisplayName = "Update Post", ParentPermissionDefinitionId = "6d807b00-447b-4e7f-8255-99912e4024e4" },
                new PermissionDefinition { Id = "29a67ad6-4f24-42fa-b79c-18aa350fe224", Name = "ADMIN_POST_DELETE", DisplayName = "Delete Post", ParentPermissionDefinitionId = "6d807b00-447b-4e7f-8255-99912e4024e4" }
            );

            // ADMIN_HEADING children
            builder.HasData(
                new PermissionDefinition { Id = "9f24f6b8-d146-47b6-b09b-780983b14521", Name = "ADMIN_HEADING_CREATE", DisplayName = "Create Heading", ParentPermissionDefinitionId = "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                new PermissionDefinition { Id = "70be0e0a-8d40-4c72-a0d4-aeef641dbc8f", Name = "ADMIN_HEADING_UPDATE", DisplayName = "Update Heading", ParentPermissionDefinitionId = "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                new PermissionDefinition { Id = "affe5dc6-b91c-430b-8516-eb8a80714b7b", Name = "ADMIN_HEADING_DELETE", DisplayName = "Delete Heading", ParentPermissionDefinitionId = "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" }
            );

            // ADMIN_SECTION children
            builder.HasData(
                new PermissionDefinition { Id = "3059ac0b-ecf8-4e95-acd7-f2a5378886fb", Name = "ADMIN_SECTION_CREATE", DisplayName = "Create Section", ParentPermissionDefinitionId = "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                new PermissionDefinition { Id = "68992dc4-c2d2-4479-bf0c-f33d4a511a9d", Name = "ADMIN_SECTION_UPDATE", DisplayName = "Update Section", ParentPermissionDefinitionId = "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                new PermissionDefinition { Id = "206707f8-5625-4949-ac64-7c54ab7f82a5", Name = "ADMIN_SECTION_DELETE", DisplayName = "Delete Section", ParentPermissionDefinitionId = "f25163b7-43e5-4eba-bccb-95f8d2454f0a" }
            );

            // ADMIN_CATEGORY children
            builder.HasData(
                new PermissionDefinition { Id = "8e3404a5-4929-449b-ad84-e83efeda6290", Name = "ADMIN_CATEGORY_CREATE", DisplayName = "Create Category", ParentPermissionDefinitionId = "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                new PermissionDefinition { Id = "4e479fa5-ad75-4c84-9e61-fda5d262b63b", Name = "ADMIN_CATEGORY_UPDATE", DisplayName = "Update Category", ParentPermissionDefinitionId = "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                new PermissionDefinition { Id = "8af1ed15-b6f0-46bf-97ba-026273eb55fd", Name = "ADMIN_CATEGORY_DELETE", DisplayName = "Delete Category", ParentPermissionDefinitionId = "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" }
            );
        }
    }
}
