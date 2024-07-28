using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionDefinitions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    ParentPermissionDefinitionId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionDefinitions_PermissionDefinitions_ParentPermissio~",
                        column: x => x.ParentPermissionDefinitionId,
                        principalTable: "PermissionDefinitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastOnlineTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    IsGranted = table.Column<bool>(type: "boolean", nullable: false),
                    ParentPermissionId = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<string>(type: "text", nullable: true),
                    PermissionDefinitionId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionDefinitions_PermissionDefinitionId",
                        column: x => x.PermissionDefinitionId,
                        principalTable: "PermissionDefinitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_ParentPermissionId",
                        column: x => x.ParentPermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatorId = table.Column<string>(type: "text", nullable: true),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<string>(type: "text", nullable: true),
                    IsVisibleForCreator = table.Column<bool>(type: "boolean", nullable: false),
                    IsVisibleForReceiver = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ChatId = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    IsVisibleForOwner = table.Column<bool>(type: "boolean", nullable: false),
                    IsVisibleForReceiver = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bac43a5e-f7bb-4448-b12f-1add431ccbbf", null, "Moderator", "MODERATOR" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", null, "Administrator", "ADMINISTRATOR" },
                    { "dac42a6e-f7bb-4448-b3cf-1add431ccbbf", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "LastName", "LastOnlineTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "076f24af-8934-4bf2-8d4e-03a5b48db4f4", 0, "2e543714-3c99-4cc5-a960-bace1e3ccaa4", null, "moderator@localhost.com", true, "System", "Moderator", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "MODERATOR@LOCALHOST.COM", "MODERATOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPUd/P7QX/F9DWBHOuBA1kLH8MSnWIGtpxfua6aAK8DlcXr6RgdhsaxtUMiihZmrlw==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8e4b52f6-e014-4786-8c26-617dd50b5374", false, "moderator@localhost.com" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "f3324c11-9b66-4ea5-ac62-e96cfe1ba114", null, "admin@localhost.com", true, "System", "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEELqpa23vG6Vw3Veb7etxwu+hp9+0IgfHVvYOM9ATo/v9Z82PfmNgCdp8xJquZGy6A==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d8d56364-130a-45fe-9e0e-4fd0aac0d944", false, "admin@localhost.com" },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, "be70577c-f1bc-4818-98c4-c0ad663da84f", null, "user@localhost.com", true, "System", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEJeefBlBcfFoVll7eN7zgfXVv12dINZs3/+xAhdJKY8/C3UgV2dObSymltX06iOqgg==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b2ed598b-a9d0-45ad-a455-81bd2bf5c973", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "PermissionDefinitions",
                columns: new[] { "Id", "DisplayName", "Name", "ParentPermissionDefinitionId" },
                values: new object[,]
                {
                    { "1d42748d-3f19-4f1b-bde0-786a4a245f46", "Category", "FORUM_CATEGORY", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "336e4081-f40d-4e45-bcc5-adb0c04d016f", "Heading", "FORUM_HEADING", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "433a025d-e09e-414c-8fa2-b3d8fc67ecbb", "Message", "FORUM_MESSAGE", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "6d807b00-447b-4e7f-8255-99912e4024e4", "Post", "ADMIN_POST", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e", "Heading", "ADMIN_HEADING", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "8fdcb439-e635-466f-ae81-d7b161fe9a80", "Profile", "FORUM_PROFILE", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4", "Category", "ADMIN_CATEGORY", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "d9687026-5c6b-44c8-a4cf-31a7f7ada844", "Section", "FORUM_SECTION", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "efd0da20-755d-4dcb-a10f-617d84bc52aa", "Post", "FORUM_POST", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "f25163b7-43e5-4eba-bccb-95f8d2454f0a", "Section", "ADMIN_SECTION", "87800b42-e5dc-41e1-845a-789c387a9c8c" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "DisplayName", "IsGranted", "Name", "ParentPermissionId", "PermissionDefinitionId", "RoleId" },
                values: new object[,]
                {
                    { "0c125c40-7d4e-41de-a00f-c9748142d35a", null, true, "FORUM_CAN_OPEN_HEADING", null, null, "bac43a5e-f7bb-4448-b12f-1add431ccbbf" },
                    { "25315678-0f4a-4a38-b82c-83a130ac4992", null, true, "FORUM_CAN_OPEN_HEADING", null, null, "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" },
                    { "532be471-dd63-4a39-ba2a-4fdc31dc432b", null, true, "FORUM_PROFILE_PAGE", null, null, "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" },
                    { "9519adb7-9611-40bc-bd8e-2d71b5097755", null, true, "FORUM_CAN_OPEN_HEADING", null, null, "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },
                    { "a0737557-3282-45eb-b8ed-daa1cc2bc924", null, true, "FORUM_PROFILE_PAGE", null, null, "bac43a5e-f7bb-4448-b12f-1add431ccbbf" },
                    { "b426d1e0-4afe-4752-abb1-444f593ca9d3", null, true, "FORUM_CAN_REPLY", null, null, "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },
                    { "dc9aff7b-7de7-4ef3-90a1-047f8ef935f4", null, true, "FORUM_PROFILE_PAGE", null, null, "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },
                    { "e87f7d83-721e-4e3d-84c4-9b7f48215a84", null, true, "FORUM_CAN_REPLY", null, null, "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" },
                    { "f46684f5-6513-4a7d-bbdd-0e43a395a38c", null, true, "FORUM_CAN_REPLY", null, null, "bac43a5e-f7bb-4448-b12f-1add431ccbbf" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bac43a5e-f7bb-4448-b12f-1add431ccbbf", "076f24af-8934-4bf2-8d4e-03a5b48db4f4" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                    { "dac42a6e-f7bb-4448-b3cf-1add431ccbbf", "9e224968-33e4-4652-b7b7-8574d048cdb9" }
                });

            migrationBuilder.InsertData(
                table: "PermissionDefinitions",
                columns: new[] { "Id", "DisplayName", "Name", "ParentPermissionDefinitionId" },
                values: new object[,]
                {
                    { "0121f80b-f006-4b98-98b6-72fd0d294a9c", "Create Section", "FORUM_SECTION_CREATE", "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                    { "03508f20-5c3c-4167-9f41-d8cee9c35620", "Send Message", "FORUM_MESSAGE_SEND", "433a025d-e09e-414c-8fa2-b3d8fc67ecbb" },
                    { "206707f8-5625-4949-ac64-7c54ab7f82a5", "Delete Section", "ADMIN_SECTION_DELETE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "29a67ad6-4f24-42fa-b79c-18aa350fe224", "Delete Post", "ADMIN_POST_DELETE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "3059ac0b-ecf8-4e95-acd7-f2a5378886fb", "Create Section", "ADMIN_SECTION_CREATE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "32b3175a-dd42-4431-bca1-9ab430ae84df", "Create Category", "FORUM_CATEGORY_CREATE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "36f5b8ce-f602-4268-ac03-047a92f255d8", "Delete Section", "FORUM_SECTION_DELETE", "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                    { "4b35a46b-0ee0-48f5-a44f-b1317c4e3af2", "Update Heading", "FORUM_HEADING_UPDATE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "4e479fa5-ad75-4c84-9e61-fda5d262b63b", "Update Category", "ADMIN_CATEGORY_UPDATE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "58b4d6c9-7db7-490b-b118-7fff4839fe69", "Update Post", "FORUM_POST_UPDATE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "5cdd6187-b295-4ea5-ab2f-18355dab03bc", "Update Section", "FORUM_SECTION_UPDATE", "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                    { "68992dc4-c2d2-4479-bf0c-f33d4a511a9d", "Update Section", "ADMIN_SECTION_UPDATE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "69860332-d98b-45c5-b3df-0a3ea6d02bda", "Update Post", "ADMIN_POST_UPDATE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "6d4df87c-cf17-4db4-90e1-590b68e07e50", "Create Heading", "FORUM_HEADING_CREATE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "70be0e0a-8d40-4c72-a0d4-aeef641dbc8f", "Update Heading", "ADMIN_HEADING_UPDATE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "72a2d85e-80f4-4bd4-abee-b98842122219", "Update Category", "FORUM_CATEGORY_UPDATE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "8af1ed15-b6f0-46bf-97ba-026273eb55fd", "Delete Category", "ADMIN_CATEGORY_DELETE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "8c87ab42-975a-4016-92a8-ec8e34852fbf", "Create Post", "FORUM_POST_CREATE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "8e3404a5-4929-449b-ad84-e83efeda6290", "Create Category", "ADMIN_CATEGORY_CREATE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "94466734-1998-4237-90c3-0b3473889dbd", "View Profile Page", "FORUM_PROFILE_VIEW", "8fdcb439-e635-466f-ae81-d7b161fe9a80" },
                    { "9f24f6b8-d146-47b6-b09b-780983b14521", "Create Heading", "ADMIN_HEADING_CREATE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "aa55c85d-33ad-45ee-9dff-6d78aaf86a9c", "Create Post", "ADMIN_POST_CREATE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "affe5dc6-b91c-430b-8516-eb8a80714b7b", "Delete Heading", "ADMIN_HEADING_DELETE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "edae4f5c-d414-4753-b20c-7f6d32b8ed23", "Delete Post", "FORUM_POST_DELETE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "f258398c-250e-4d24-8b5b-327b6354f447", "Delete Category", "FORUM_CATEGORY_DELETE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "f3311407-5848-4682-98ae-3a02701f1211", "Delete Heading", "FORUM_HEADING_DELETE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_CreatorId",
                table: "Chats",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ReceiverId",
                table: "Chats",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_OwnerId",
                table: "Messages",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionDefinitions_ParentPermissionDefinitionId",
                table: "PermissionDefinitions",
                column: "ParentPermissionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentPermissionId",
                table: "Permissions",
                column: "ParentPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionDefinitionId",
                table: "Permissions",
                column: "PermissionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "PermissionDefinitions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
