using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PermissionDefinitions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentPermissionDefinitionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionDefinitions_PermissionDefinitions_ParentPermissionDefinitionId",
                        column: x => x.ParentPermissionDefinitionId,
                        principalTable: "PermissionDefinitions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "PermissionDefinitions",
                columns: new[] { "Id", "DisplayName", "Name", "ParentPermissionDefinitionId" },
                values: new object[,]
                {
                    { "87800b42-e5dc-41e1-845a-789c387a9c8c", "Admin", "ADMIN", null },
                    { "95e10e0e-7e21-4a7c-849b-30a2e82a61b8", "Forum", "FORUM", null }
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "0c125c40-7d4e-41de-a00f-c9748142d35a",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "25315678-0f4a-4a38-b82c-83a130ac4992",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "532be471-dd63-4a39-ba2a-4fdc31dc432b",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "9519adb7-9611-40bc-bd8e-2d71b5097755",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "a0737557-3282-45eb-b8ed-daa1cc2bc924",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "b426d1e0-4afe-4752-abb1-444f593ca9d3",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "dc9aff7b-7de7-4ef3-90a1-047f8ef935f4",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "e87f7d83-721e-4e3d-84c4-9b7f48215a84",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "f46684f5-6513-4a7d-bbdd-0e43a395a38c",
                column: "DisplayName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5811ab05-fdc0-4a8b-a874-7bde17d85fe4", "AQAAAAIAAYagAAAAEKAS6fizFDoE/GXiqC8Qz4t10TBBNuH6mXSkuvWdnULbDXRoTkOQQCkYoUAQmWwRAw==", "b6d4aecd-bbe5-435e-9cf0-ff7e18b46212" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a32d41c-f661-4e34-9e48-85c3dd060cf1", "AQAAAAIAAYagAAAAEBs6y3IBW4dNzcHl2ZvltCTuyOdC8ngKz/NFPU1gPyBRXX3mlaDKxHJThjjhgrbY1Q==", "64c5f9c0-280c-46fa-bcc5-5987d060bda0" });

            migrationBuilder.InsertData(
                table: "PermissionDefinitions",
                columns: new[] { "Id", "DisplayName", "Name", "ParentPermissionDefinitionId" },
                values: new object[,]
                {
                    { "1d42748d-3f19-4f1b-bde0-786a4a245f46", "Category", "FORUM_CATEGORY", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "336e4081-f40d-4e45-bcc5-adb0c04d016f", "Heading", "FORUM_HEADING", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "433a025d-e09e-414c-8fa2-b3d8fc67ecbb", "Message", "FORUM_MESSAGE", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "58b4d6c9-7db7-490b-b118-7fff4839fe69", "Update Post", "FORUM_POST_UPDATE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "6d807b00-447b-4e7f-8255-99912e4024e4", "Post", "ADMIN_POST", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e", "Heading", "ADMIN_HEADING", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "8c87ab42-975a-4016-92a8-ec8e34852fbf", "Create Post", "FORUM_POST_CREATE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "8fdcb439-e635-466f-ae81-d7b161fe9a80", "Profile", "FORUM_PROFILE", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4", "Category", "ADMIN_CATEGORY", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "d9687026-5c6b-44c8-a4cf-31a7f7ada844", "Section", "FORUM_SECTION", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "edae4f5c-d414-4753-b20c-7f6d32b8ed23", "Delete Post", "FORUM_POST_DELETE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "efd0da20-755d-4dcb-a10f-617d84bc52aa", "Post", "FORUM_POST", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "f25163b7-43e5-4eba-bccb-95f8d2454f0a", "Section", "ADMIN_SECTION", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "0121f80b-f006-4b98-98b6-72fd0d294a9c", "Create Section", "FORUM_SECTION_CREATE", "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                    { "03508f20-5c3c-4167-9f41-d8cee9c35620", "Send Message", "FORUM_MESSAGE_SEND", "433a025d-e09e-414c-8fa2-b3d8fc67ecbb" },
                    { "206707f8-5625-4949-ac64-7c54ab7f82a5", "Delete Section", "ADMIN_SECTION_DELETE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "29a67ad6-4f24-42fa-b79c-18aa350fe224", "Delete Post", "ADMIN_POST_DELETE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "3059ac0b-ecf8-4e95-acd7-f2a5378886fb", "Create Section", "ADMIN_SECTION_CREATE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "32b3175a-dd42-4431-bca1-9ab430ae84df", "Create Category", "FORUM_CATEGORY_CREATE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "36f5b8ce-f602-4268-ac03-047a92f255d8", "Delete Section", "FORUM_SECTION_DELETE", "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                    { "4b35a46b-0ee0-48f5-a44f-b1317c4e3af2", "Update Heading", "FORUM_HEADING_UPDATE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "4e479fa5-ad75-4c84-9e61-fda5d262b63b", "Update Category", "ADMIN_CATEGORY_UPDATE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "5cdd6187-b295-4ea5-ab2f-18355dab03bc", "Update Section", "FORUM_SECTION_UPDATE", "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                    { "68992dc4-c2d2-4479-bf0c-f33d4a511a9d", "Update Section", "ADMIN_SECTION_UPDATE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "69860332-d98b-45c5-b3df-0a3ea6d02bda", "Update Post", "ADMIN_POST_UPDATE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "6d4df87c-cf17-4db4-90e1-590b68e07e50", "Create Heading", "FORUM_HEADING_CREATE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "70be0e0a-8d40-4c72-a0d4-aeef641dbc8f", "Update Heading", "ADMIN_HEADING_UPDATE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "72a2d85e-80f4-4bd4-abee-b98842122219", "Update Category", "FORUM_CATEGORY_UPDATE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "8af1ed15-b6f0-46bf-97ba-026273eb55fd", "Delete Category", "ADMIN_CATEGORY_DELETE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "8e3404a5-4929-449b-ad84-e83efeda6290", "Create Category", "ADMIN_CATEGORY_CREATE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "94466734-1998-4237-90c3-0b3473889dbd", "View Profile Page", "FORUM_PROFILE_VIEW", "8fdcb439-e635-466f-ae81-d7b161fe9a80" },
                    { "9f24f6b8-d146-47b6-b09b-780983b14521", "Create Heading", "ADMIN_HEADING_CREATE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "aa55c85d-33ad-45ee-9dff-6d78aaf86a9c", "Create Post", "ADMIN_POST_CREATE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "affe5dc6-b91c-430b-8516-eb8a80714b7b", "Delete Heading", "ADMIN_HEADING_DELETE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "f258398c-250e-4d24-8b5b-327b6354f447", "Delete Category", "FORUM_CATEGORY_DELETE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "f3311407-5848-4682-98ae-3a02701f1211", "Delete Heading", "FORUM_HEADING_DELETE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionDefinitions_ParentPermissionDefinitionId",
                table: "PermissionDefinitions",
                column: "ParentPermissionDefinitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionDefinitions");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7670ad3c-6138-4795-88f3-382d460476ec", "AQAAAAIAAYagAAAAEAnk/rh1bU0sXh6pQhhFAM+Z3BYwbm2xuvEh1juMIqcpnRwoKXoNndjPBG6wfoKYqQ==", "d7a28dfd-adc6-4c38-bda8-bb442f021cdf" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1854dfbf-9edd-416f-a140-9745baaedca5", "AQAAAAIAAYagAAAAELNwt8tVLBCSJ8C7LvPxG4GzTFojsdWcsbzq93t1/r91YjdB56Pif9ni9Cdnntg2FA==", "2dc766f6-6bc5-4b90-a1f0-7a140ef8696a" });
        }
    }
}
