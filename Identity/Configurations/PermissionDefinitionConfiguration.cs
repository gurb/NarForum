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
                new PermissionDefinition { Id = "8c87ab42-975a-4016-92a8-ec8e34852fbf", Name = "FORUM_POST_CREATE", DisplayName = "Create Post", ParentPermissionDefinitionId = "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                new PermissionDefinition { Id = "58b4d6c9-7db7-490b-b118-7fff4839fe69", Name = "FORUM_POST_UPDATE", DisplayName = "Update Post", ParentPermissionDefinitionId = "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                new PermissionDefinition { Id = "edae4f5c-d414-4753-b20c-7f6d32b8ed23", Name = "FORUM_POST_DELETE", DisplayName = "Delete Post", ParentPermissionDefinitionId = "efd0da20-755d-4dcb-a10f-617d84bc52aa" }
            );

            // FORUM_HEADING children
            builder.HasData(
                new PermissionDefinition { Id = "6d4df87c-cf17-4db4-90e1-590b68e07e50", Name = "FORUM_HEADING_CREATE", DisplayName = "Create Heading", ParentPermissionDefinitionId = "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                new PermissionDefinition { Id = "4b35a46b-0ee0-48f5-a44f-b1317c4e3af2", Name = "FORUM_HEADING_UPDATE", DisplayName = "Update Heading", ParentPermissionDefinitionId = "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                new PermissionDefinition { Id = "f3311407-5848-4682-98ae-3a02701f1211", Name = "FORUM_HEADING_DELETE", DisplayName = "Delete Heading", ParentPermissionDefinitionId = "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                new PermissionDefinition { Id = "3b68baff-2a60-4899-9e04-e66d7885de41", Name = "FORUM_HEADING_PIN", DisplayName = "Pin Heading", ParentPermissionDefinitionId = "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                new PermissionDefinition { Id = "b79b4860-25b1-44cd-8d74-9c46f0f308c6", Name = "FORUM_HEADING_LOCK", DisplayName = "Lock Heading", ParentPermissionDefinitionId = "336e4081-f40d-4e45-bcc5-adb0c04d016f" }
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
                new PermissionDefinition { Id = "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4", Name = "ADMIN_CATEGORY", DisplayName = "Category", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "ea105968-d9b2-4534-a7be-8ff26911e6d4", Name = "ADMIN_STATIC_PAGE", DisplayName = "Static Page", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "60bff600-0087-4b56-be68-a2193adc4e74", Name = "ADMIN_BLOG_POST", DisplayName = "Blog Post", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "7a0d912d-6939-41e2-b5bf-bb1679b4444a", Name = "ADMIN_BLOG_CATEGORY", DisplayName = "Blog Category", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "8f512611-db14-4ae8-8c51-bd6ee781fd63", Name = "ADMIN_BLOG_COMMENT", DisplayName = "Blog Comment", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "dfe92ad3-1007-417c-bba0-ddf1498431ea", Name = "ADMIN_FILE", DisplayName = "File", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "2eb69c14-bce8-43a8-93b0-d6f4919975e5", Name = "ADMIN_CONTACT", DisplayName = "Contact", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "f61fb3eb-4498-4319-b618-615fbf962c26", Name = "ADMIN_REPORT", DisplayName = "Report", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "a5fa386c-fc18-4da6-a173-4788894e1df1", Name = "ADMIN_FORUM_SETTINGS", DisplayName = "Forum Settings", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "ba8b1242-49b5-4706-b641-e07d23b78884", Name = "ADMIN_AUTHORIZATION", DisplayName = "Authorization", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                new PermissionDefinition { Id = "038d6a97-5afc-4a47-b8c4-0dc1ef4e53dc", Name = "ADMIN_USER", DisplayName = "User", ParentPermissionDefinitionId = "87800b42-e5dc-41e1-845a-789c387a9c8c" }
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

            // ADMIN_STATIC_PAGE children
            builder.HasData(
                new PermissionDefinition { Id = "f9ac31ce-3d30-4590-aab1-fce1694a7690", Name = "ADMIN_STATIC_PAGE_CREATE", DisplayName = "Create Static Page", ParentPermissionDefinitionId = "ea105968-d9b2-4534-a7be-8ff26911e6d4" },
                new PermissionDefinition { Id = "4fd10b35-bfba-472c-884c-79106acb29d0", Name = "ADMIN_STATIC_PAGE_UPDATE", DisplayName = "Update Static Page", ParentPermissionDefinitionId = "ea105968-d9b2-4534-a7be-8ff26911e6d4" },
                new PermissionDefinition { Id = "7ef1f32e-97c6-4bb9-bc07-57a5384e032f", Name = "ADMIN_STATIC_PAGE_DELETE", DisplayName = "Delete Static Page", ParentPermissionDefinitionId = "ea105968-d9b2-4534-a7be-8ff26911e6d4" },
                new PermissionDefinition { Id = "e8e6009a-cf3b-41a4-89ef-0ae44fe53bbc", Name = "ADMIN_STATIC_PAGE_DRAFT", DisplayName = "Draft Static Page", ParentPermissionDefinitionId = "ea105968-d9b2-4534-a7be-8ff26911e6d4" },
                new PermissionDefinition { Id = "3075314b-4f93-4998-81c8-f80ffc9632b7", Name = "ADMIN_STATIC_PAGE_PUBLISH", DisplayName = "Delete Static Page", ParentPermissionDefinitionId = "ea105968-d9b2-4534-a7be-8ff26911e6d4" }
            );

            // ADMIN_BLOG_POST children
            builder.HasData(
                new PermissionDefinition { Id = "f1e86cb5-37df-423f-9b77-c75c4d8cc4d3", Name = "ADMIN_BLOG_POST_CREATE", DisplayName = "Create Blog Post", ParentPermissionDefinitionId = "60bff600-0087-4b56-be68-a2193adc4e74" },
                new PermissionDefinition { Id = "6fe53ad5-e173-44af-a6a8-224ee49f15fe", Name = "ADMIN_BLOG_POST_UPDATE", DisplayName = "Update Blog Post", ParentPermissionDefinitionId = "60bff600-0087-4b56-be68-a2193adc4e74" },
                new PermissionDefinition { Id = "1bed742a-e365-430b-a38f-e0bf280b3c3c", Name = "ADMIN_BLOG_POST_DELETE", DisplayName = "Delete Blog Post", ParentPermissionDefinitionId = "60bff600-0087-4b56-be68-a2193adc4e74" },
                new PermissionDefinition { Id = "94014f4f-7632-4b22-b4e5-208e21a62ff3", Name = "ADMIN_BLOG_POST_DRAFT", DisplayName = "Draft Blog Post", ParentPermissionDefinitionId = "60bff600-0087-4b56-be68-a2193adc4e74" },
                new PermissionDefinition { Id = "837a53e1-27c9-46c6-87d7-3b8d6ca08deb", Name = "ADMIN_BLOG_POST_PUBLISH", DisplayName = "Delete Blog Post", ParentPermissionDefinitionId = "60bff600-0087-4b56-be68-a2193adc4e74" }
            );

            // ADMIN_BLOG_CATEGORY children
            builder.HasData(
                new PermissionDefinition { Id = "bf45e6ac-c5b6-4545-bb88-13c5247d74d9", Name = "ADMIN_BLOG_CATEGORY_CREATE", DisplayName = "Create Blog Category", ParentPermissionDefinitionId = "7a0d912d-6939-41e2-b5bf-bb1679b4444a" },
                new PermissionDefinition { Id = "2c9ba66d-3843-4e1e-8310-566dfeb2b76a", Name = "ADMIN_BLOG_CATEGORY_UPDATE", DisplayName = "Update Blog Category", ParentPermissionDefinitionId = "7a0d912d-6939-41e2-b5bf-bb1679b4444a" },
                new PermissionDefinition { Id = "5dd47b71-652b-4820-ab37-961922ca9f9f", Name = "ADMIN_BLOG_CATEGORY_DELETE", DisplayName = "Delete Blog Category", ParentPermissionDefinitionId = "7a0d912d-6939-41e2-b5bf-bb1679b4444a" }
            );

            // ADMIN_BLOG_COMMENT children
            builder.HasData(
                new PermissionDefinition { Id = "eba68e19-aab6-4850-afc5-212af0170223", Name = "ADMIN_BLOG_COMMENT_DELETE", DisplayName = "Delete Blog Comment", ParentPermissionDefinitionId = "8f512611-db14-4ae8-8c51-bd6ee781fd63" }
            );

            // ADMIN_FILE children
            builder.HasData(
                new PermissionDefinition { Id = "7b840a2b-6fd5-46d6-88be-3deab30d468a", Name = "ADMIN_FILE_UPLOAD", DisplayName = "Upload File", ParentPermissionDefinitionId = "dfe92ad3-1007-417c-bba0-ddf1498431ea" }
            );

            // ADMIN_CONTACT children
            builder.HasData(
                new PermissionDefinition { Id = "a88f9a5b-de8e-4ca0-9849-d8be17a7d355", Name = "ADMIN_CONTACT_DELETE", DisplayName = "Delete Contact", ParentPermissionDefinitionId = "2eb69c14-bce8-43a8-93b0-d6f4919975e5" }
            );

            // ADMIN_REPORT children
            builder.HasData(
                new PermissionDefinition { Id = "c49c9c80-5531-4d97-923c-9c32220c0ce4", Name = "ADMIN_REPORT_DELETE", DisplayName = "Delete Report", ParentPermissionDefinitionId = "f61fb3eb-4498-4319-b618-615fbf962c26" }
            );

            // ADMIN_FORUM_SETTINGS children
            builder.HasData(
                new PermissionDefinition { Id = "e022f309-249a-43d0-b04c-0e385faf4b2f", Name = "ADMIN_FORUM_SETTINGS_SMTP_SAVE", DisplayName = "Save SMTP Settings", ParentPermissionDefinitionId = "a5fa386c-fc18-4da6-a173-4788894e1df1" }
            );

            // ADMIN_AUTHORIZATION children
            builder.HasData(
                new PermissionDefinition { Id = "5d3da4f1-95a7-4fc4-abac-df5f782f1e79", Name = "ADMIN_AUTHORIZATION_PERMISSION", DisplayName = "Permission", ParentPermissionDefinitionId = "ba8b1242-49b5-4706-b641-e07d23b78884" },
                new PermissionDefinition { Id = "0e894f8b-569c-45ae-bcec-257200d23c63", Name = "ADMIN_AUTHORIZATION_PERMISSION_DEFINITION", DisplayName = "Permission Definition", ParentPermissionDefinitionId = "ba8b1242-49b5-4706-b641-e07d23b78884" },
                new PermissionDefinition { Id = "2c15ed97-173a-41a8-8dcf-b16cf7090aec", Name = "ADMIN_AUTHORIZATION_ROLE", DisplayName = "Role", ParentPermissionDefinitionId = "ba8b1242-49b5-4706-b641-e07d23b78884" }
            );

            // ADMIN_AUTHORIZATION_PERMISSION children
            builder.HasData(
                new PermissionDefinition { Id = "8347ac9a-2b9a-4b03-9cb5-3855adc46355", Name = "ADMIN_AUTHORIZATION_PERMISSION_STATUS_CHANGE", DisplayName = "Change Permission Status", ParentPermissionDefinitionId = "5d3da4f1-95a7-4fc4-abac-df5f782f1e79" },
                new PermissionDefinition { Id = "70d82cd8-8910-4447-af13-caddf6a1f55b", Name = "ADMIN_AUTHORIZATION_PERMISSIONS_REFRESH", DisplayName = "Refresh Permissions", ParentPermissionDefinitionId = "5d3da4f1-95a7-4fc4-abac-df5f782f1e79" }
            );

            // ADMIN_AUTHORIZATION_PERMISSION_DEFINITIONS children
            builder.HasData(
                new PermissionDefinition { Id = "a3455235-c9b3-4e67-b3ae-aacf6751295d", Name = "ADMIN_AUTHORIZATION_PERMISSION_DEFINITION_CREATE", DisplayName = "Create Permission Definition", ParentPermissionDefinitionId = "0e894f8b-569c-45ae-bcec-257200d23c63" },
                new PermissionDefinition { Id = "cb42ac4b-1daa-4f7c-856c-2af6603473e5", Name = "ADMIN_AUTHORIZATION_PERMISSION_DEFINITION_UPDATE", DisplayName = "Update Permission Definition", ParentPermissionDefinitionId = "0e894f8b-569c-45ae-bcec-257200d23c63" },
                new PermissionDefinition { Id = "54463466-4952-4613-af9c-9b503b4960b7", Name = "ADMIN_AUTHORIZATION_PERMISSION_DEFINITION_DELETE", DisplayName = "Delete Permission Definition", ParentPermissionDefinitionId = "0e894f8b-569c-45ae-bcec-257200d23c63" },
                new PermissionDefinition { Id = "7ae52279-9c38-4f0b-a1f1-e401db327816", Name = "ADMIN_AUTHORIZATION_PERMISSION_DEFINITIONS_REFRESH", DisplayName = "Refresh Permission Definitions", ParentPermissionDefinitionId = "0e894f8b-569c-45ae-bcec-257200d23c63" }
            );

            // ADMIN_AUTHORIZATION_ROLE children
            builder.HasData(
                new PermissionDefinition { Id = "29dfed48-ac55-4439-ba79-465e29d0c3b5", Name = "ADMIN_AUTHORIZATION_ROLE_CREATE", DisplayName = "Create Role", ParentPermissionDefinitionId = "2c15ed97-173a-41a8-8dcf-b16cf7090aec" },
                new PermissionDefinition { Id = "4b9c7722-f40b-403a-8a9b-670d91541657", Name = "ADMIN_AUTHORIZATION_ROLE_UPDATE", DisplayName = "Update Role", ParentPermissionDefinitionId = "2c15ed97-173a-41a8-8dcf-b16cf7090aec" },
                new PermissionDefinition { Id = "25195f3b-ba45-4e1b-9472-a44feefbbc65", Name = "ADMIN_AUTHORIZATION_ROLE_DELETE", DisplayName = "Delete Role", ParentPermissionDefinitionId = "2c15ed97-173a-41a8-8dcf-b16cf7090aec" }
            );

            // ADMIN_USER children
            builder.HasData(
                new PermissionDefinition { Id = "2da95710-6b31-413e-9e8b-979e58d8888d", Name = "ADMIN_USER_CREATE", DisplayName = "Create User", ParentPermissionDefinitionId = "038d6a97-5afc-4a47-b8c4-0dc1ef4e53dc" },
                new PermissionDefinition { Id = "55506640-2c10-4578-9391-78c3a8d04881", Name = "ADMIN_USER_UPDATE", DisplayName = "Update User", ParentPermissionDefinitionId = "038d6a97-5afc-4a47-b8c4-0dc1ef4e53dc" }
            );
        }
    }
}
