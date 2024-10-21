using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsChanged = table.Column<bool>(type: "boolean", nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRequests", x => x.Id);
                });

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
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Rank = table.Column<string>(type: "text", nullable: true),
                    PostCounter = table.Column<int>(type: "integer", nullable: false),
                    HeadingCounter = table.Column<int>(type: "integer", nullable: false),
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "HeadingCounter", "IsBlocked", "LastName", "LastOnlineTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostCounter", "Rank", "RegisterDate", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "076f24af-8934-4bf2-8d4e-03a5b48db4f4", 0, "9f933f75-4909-49b2-b9e5-707891609a76", null, "moderator@localhost.com", true, "System", 0, false, "Moderator", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "MODERATOR@LOCALHOST.COM", "MODERATOR@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAM67xLc0gNbDQx6VWowfzK0clvg1aEFpRvsIo4hRG8QxtWQPRe8IaAMDObqBfF6RQ==", null, false, 0, null, new DateTime(2024, 10, 21, 9, 36, 9, 673, DateTimeKind.Utc).AddTicks(5316), null, "58cc46d9-3020-4e4e-a952-e9acf515df68", false, "moderator" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "18251732-5e3b-4876-b9bb-8746961907b8", null, "admin@localhost.com", true, "System", 0, false, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEDesCfs0emIyjlAPhsgcc3r2ASxWHmcYD0VNM6XYFwc/A8FuDKPhODXiimyeWL6R9w==", null, false, 0, null, new DateTime(2024, 10, 21, 9, 36, 9, 539, DateTimeKind.Utc).AddTicks(7162), "Administrator", "9c0a5c85-db9a-44dc-9296-8f70df7be2d0", false, "admin" },
                    { "9e224968-33e4-4652-b7b7-8574d048cdb9", 0, "f656e935-504e-4007-b9fa-8a45dd6b27b2", null, "user@localhost.com", true, "System", 0, false, "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPGXe//EG76IZz97nwMPEsln7XWJpyetDfkKPzLX16s9+ATmwDbT1qK1z7ogSJraSg==", null, false, 0, null, new DateTime(2024, 10, 21, 9, 36, 9, 607, DateTimeKind.Utc).AddTicks(6982), null, "3d56483f-94cb-4ac0-9b3d-bce0642712d4", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "PermissionDefinitions",
                columns: new[] { "Id", "DisplayName", "Name", "ParentPermissionDefinitionId" },
                values: new object[,]
                {
                    { "038d6a97-5afc-4a47-b8c4-0dc1ef4e53dc", "User", "ADMIN_USER", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "1d42748d-3f19-4f1b-bde0-786a4a245f46", "Category", "FORUM_CATEGORY", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "2eb69c14-bce8-43a8-93b0-d6f4919975e5", "Contact", "ADMIN_CONTACT", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "336e4081-f40d-4e45-bcc5-adb0c04d016f", "Heading", "FORUM_HEADING", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "433a025d-e09e-414c-8fa2-b3d8fc67ecbb", "Message", "FORUM_MESSAGE", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "60bff600-0087-4b56-be68-a2193adc4e74", "Blog Post", "ADMIN_BLOG_POST", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "6d807b00-447b-4e7f-8255-99912e4024e4", "Post", "ADMIN_POST", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "7a0d912d-6939-41e2-b5bf-bb1679b4444a", "Blog Category", "ADMIN_BLOG_CATEGORY", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e", "Heading", "ADMIN_HEADING", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "8f512611-db14-4ae8-8c51-bd6ee781fd63", "Blog Comment", "ADMIN_BLOG_COMMENT", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "8fdcb439-e635-466f-ae81-d7b161fe9a80", "Profile", "FORUM_PROFILE", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "a5fa386c-fc18-4da6-a173-4788894e1df1", "Forum Settings", "ADMIN_FORUM_SETTINGS", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "ba8b1242-49b5-4706-b641-e07d23b78884", "Authorization", "ADMIN_AUTHORIZATION", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4", "Category", "ADMIN_CATEGORY", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "d9687026-5c6b-44c8-a4cf-31a7f7ada844", "Section", "FORUM_SECTION", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "dfe92ad3-1007-417c-bba0-ddf1498431ea", "File", "ADMIN_FILE", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "ea105968-d9b2-4534-a7be-8ff26911e6d4", "Static Page", "ADMIN_STATIC_PAGE", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "efd0da20-755d-4dcb-a10f-617d84bc52aa", "Post", "FORUM_POST", "95e10e0e-7e21-4a7c-849b-30a2e82a61b8" },
                    { "f25163b7-43e5-4eba-bccb-95f8d2454f0a", "Section", "ADMIN_SECTION", "87800b42-e5dc-41e1-845a-789c387a9c8c" },
                    { "f61fb3eb-4498-4319-b618-615fbf962c26", "Report", "ADMIN_REPORT", "87800b42-e5dc-41e1-845a-789c387a9c8c" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "DisplayName", "IsGranted", "Name", "ParentPermissionId", "PermissionDefinitionId", "RoleId" },
                values: new object[] { "0e6f1e30-aaa1-49d3-8918-419291f9eebe", "Admin", true, "ADMIN", null, "87800b42-e5dc-41e1-845a-789c387a9c8c", "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" });

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
                    { "0e894f8b-569c-45ae-bcec-257200d23c63", "Permission Definition", "ADMIN_AUTHORIZATION_PERMISSION_DEFINITION", "ba8b1242-49b5-4706-b641-e07d23b78884" },
                    { "1bed742a-e365-430b-a38f-e0bf280b3c3c", "Delete Blog Post", "ADMIN_BLOG_POST_DELETE", "60bff600-0087-4b56-be68-a2193adc4e74" },
                    { "206707f8-5625-4949-ac64-7c54ab7f82a5", "Delete Section", "ADMIN_SECTION_DELETE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "29a67ad6-4f24-42fa-b79c-18aa350fe224", "Delete Post", "ADMIN_POST_DELETE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "2c15ed97-173a-41a8-8dcf-b16cf7090aec", "Role", "ADMIN_AUTHORIZATION_ROLE", "ba8b1242-49b5-4706-b641-e07d23b78884" },
                    { "2c9ba66d-3843-4e1e-8310-566dfeb2b76a", "Update Blog Category", "ADMIN_BLOG_CATEGORY_UPDATE", "7a0d912d-6939-41e2-b5bf-bb1679b4444a" },
                    { "2da95710-6b31-413e-9e8b-979e58d8888d", "Create User", "ADMIN_USER_CREATE", "038d6a97-5afc-4a47-b8c4-0dc1ef4e53dc" },
                    { "3059ac0b-ecf8-4e95-acd7-f2a5378886fb", "Create Section", "ADMIN_SECTION_CREATE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "3075314b-4f93-4998-81c8-f80ffc9632b7", "Delete Static Page", "ADMIN_STATIC_PAGE_PUBLISH", "ea105968-d9b2-4534-a7be-8ff26911e6d4" },
                    { "32b3175a-dd42-4431-bca1-9ab430ae84df", "Create Category", "FORUM_CATEGORY_CREATE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "36f5b8ce-f602-4268-ac03-047a92f255d8", "Delete Section", "FORUM_SECTION_DELETE", "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                    { "3b68baff-2a60-4899-9e04-e66d7885de41", "Pin Heading", "FORUM_HEADING_PIN", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "4b35a46b-0ee0-48f5-a44f-b1317c4e3af2", "Update Heading", "FORUM_HEADING_UPDATE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "4e479fa5-ad75-4c84-9e61-fda5d262b63b", "Update Category", "ADMIN_CATEGORY_UPDATE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "4fd10b35-bfba-472c-884c-79106acb29d0", "Update Static Page", "ADMIN_STATIC_PAGE_UPDATE", "ea105968-d9b2-4534-a7be-8ff26911e6d4" },
                    { "55506640-2c10-4578-9391-78c3a8d04881", "Update User", "ADMIN_USER_UPDATE", "038d6a97-5afc-4a47-b8c4-0dc1ef4e53dc" },
                    { "58b4d6c9-7db7-490b-b118-7fff4839fe69", "Update Post", "FORUM_POST_UPDATE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "5cdd6187-b295-4ea5-ab2f-18355dab03bc", "Update Section", "FORUM_SECTION_UPDATE", "d9687026-5c6b-44c8-a4cf-31a7f7ada844" },
                    { "5d3da4f1-95a7-4fc4-abac-df5f782f1e79", "Permission", "ADMIN_AUTHORIZATION_PERMISSION", "ba8b1242-49b5-4706-b641-e07d23b78884" },
                    { "5dd47b71-652b-4820-ab37-961922ca9f9f", "Delete Blog Category", "ADMIN_BLOG_CATEGORY_DELETE", "7a0d912d-6939-41e2-b5bf-bb1679b4444a" },
                    { "68992dc4-c2d2-4479-bf0c-f33d4a511a9d", "Update Section", "ADMIN_SECTION_UPDATE", "f25163b7-43e5-4eba-bccb-95f8d2454f0a" },
                    { "69860332-d98b-45c5-b3df-0a3ea6d02bda", "Update Post", "ADMIN_POST_UPDATE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "6d4df87c-cf17-4db4-90e1-590b68e07e50", "Create Heading", "FORUM_HEADING_CREATE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "6fe53ad5-e173-44af-a6a8-224ee49f15fe", "Update Blog Post", "ADMIN_BLOG_POST_UPDATE", "60bff600-0087-4b56-be68-a2193adc4e74" },
                    { "70be0e0a-8d40-4c72-a0d4-aeef641dbc8f", "Update Heading", "ADMIN_HEADING_UPDATE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "72a2d85e-80f4-4bd4-abee-b98842122219", "Update Category", "FORUM_CATEGORY_UPDATE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "7b840a2b-6fd5-46d6-88be-3deab30d468a", "Upload File", "ADMIN_FILE_UPLOAD", "dfe92ad3-1007-417c-bba0-ddf1498431ea" },
                    { "7ef1f32e-97c6-4bb9-bc07-57a5384e032f", "Delete Static Page", "ADMIN_STATIC_PAGE_DELETE", "ea105968-d9b2-4534-a7be-8ff26911e6d4" },
                    { "837a53e1-27c9-46c6-87d7-3b8d6ca08deb", "Delete Blog Post", "ADMIN_BLOG_POST_PUBLISH", "60bff600-0087-4b56-be68-a2193adc4e74" },
                    { "8af1ed15-b6f0-46bf-97ba-026273eb55fd", "Delete Category", "ADMIN_CATEGORY_DELETE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "8c87ab42-975a-4016-92a8-ec8e34852fbf", "Create Post", "FORUM_POST_CREATE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "8e3404a5-4929-449b-ad84-e83efeda6290", "Create Category", "ADMIN_CATEGORY_CREATE", "d2a3ae9f-c13e-459d-b5b6-3fe5937cceb4" },
                    { "94014f4f-7632-4b22-b4e5-208e21a62ff3", "Draft Blog Post", "ADMIN_BLOG_POST_DRAFT", "60bff600-0087-4b56-be68-a2193adc4e74" },
                    { "94466734-1998-4237-90c3-0b3473889dbd", "View Profile Page", "FORUM_PROFILE_VIEW", "8fdcb439-e635-466f-ae81-d7b161fe9a80" },
                    { "9f24f6b8-d146-47b6-b09b-780983b14521", "Create Heading", "ADMIN_HEADING_CREATE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "a88f9a5b-de8e-4ca0-9849-d8be17a7d355", "Delete Contact", "ADMIN_CONTACT_DELETE", "2eb69c14-bce8-43a8-93b0-d6f4919975e5" },
                    { "aa55c85d-33ad-45ee-9dff-6d78aaf86a9c", "Create Post", "ADMIN_POST_CREATE", "6d807b00-447b-4e7f-8255-99912e4024e4" },
                    { "affe5dc6-b91c-430b-8516-eb8a80714b7b", "Delete Heading", "ADMIN_HEADING_DELETE", "7d6d900a-68bf-4b8c-961e-8a2a6f7f211e" },
                    { "b79b4860-25b1-44cd-8d74-9c46f0f308c6", "Lock Heading", "FORUM_HEADING_LOCK", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "bf45e6ac-c5b6-4545-bb88-13c5247d74d9", "Create Blog Category", "ADMIN_BLOG_CATEGORY_CREATE", "7a0d912d-6939-41e2-b5bf-bb1679b4444a" },
                    { "c49c9c80-5531-4d97-923c-9c32220c0ce4", "Delete Report", "ADMIN_REPORT_DELETE", "f61fb3eb-4498-4319-b618-615fbf962c26" },
                    { "e022f309-249a-43d0-b04c-0e385faf4b2f", "Save SMTP Settings", "ADMIN_FORUM_SETTINGS_SMTP_SAVE", "a5fa386c-fc18-4da6-a173-4788894e1df1" },
                    { "e8e6009a-cf3b-41a4-89ef-0ae44fe53bbc", "Draft Static Page", "ADMIN_STATIC_PAGE_DRAFT", "ea105968-d9b2-4534-a7be-8ff26911e6d4" },
                    { "eba68e19-aab6-4850-afc5-212af0170223", "Delete Blog Comment", "ADMIN_BLOG_COMMENT_DELETE", "8f512611-db14-4ae8-8c51-bd6ee781fd63" },
                    { "edae4f5c-d414-4753-b20c-7f6d32b8ed23", "Delete Post", "FORUM_POST_DELETE", "efd0da20-755d-4dcb-a10f-617d84bc52aa" },
                    { "f1e86cb5-37df-423f-9b77-c75c4d8cc4d3", "Create Blog Post", "ADMIN_BLOG_POST_CREATE", "60bff600-0087-4b56-be68-a2193adc4e74" },
                    { "f258398c-250e-4d24-8b5b-327b6354f447", "Delete Category", "FORUM_CATEGORY_DELETE", "1d42748d-3f19-4f1b-bde0-786a4a245f46" },
                    { "f3311407-5848-4682-98ae-3a02701f1211", "Delete Heading", "FORUM_HEADING_DELETE", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "f9ac31ce-3d30-4590-aab1-fce1694a7690", "Create Static Page", "ADMIN_STATIC_PAGE_CREATE", "ea105968-d9b2-4534-a7be-8ff26911e6d4" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "DisplayName", "IsGranted", "Name", "ParentPermissionId", "PermissionDefinitionId", "RoleId" },
                values: new object[] { "d4cc9401-ca88-4de3-941d-c5b2c1b960f4", "Authorization", true, "ADMIN_AUTHORIZATION", "0e6f1e30-aaa1-49d3-8918-419291f9eebe", "ba8b1242-49b5-4706-b641-e07d23b78884", "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" });

            migrationBuilder.InsertData(
                table: "PermissionDefinitions",
                columns: new[] { "Id", "DisplayName", "Name", "ParentPermissionDefinitionId" },
                values: new object[,]
                {
                    { "25195f3b-ba45-4e1b-9472-a44feefbbc65", "Delete Role", "ADMIN_AUTHORIZATION_ROLE_DELETE", "2c15ed97-173a-41a8-8dcf-b16cf7090aec" },
                    { "29dfed48-ac55-4439-ba79-465e29d0c3b5", "Create Role", "ADMIN_AUTHORIZATION_ROLE_CREATE", "2c15ed97-173a-41a8-8dcf-b16cf7090aec" },
                    { "4b9c7722-f40b-403a-8a9b-670d91541657", "Update Role", "ADMIN_AUTHORIZATION_ROLE_UPDATE", "2c15ed97-173a-41a8-8dcf-b16cf7090aec" },
                    { "54463466-4952-4613-af9c-9b503b4960b7", "Delete Permission Definition", "ADMIN_AUTHORIZATION_PERMISSION_DEFINITION_DELETE", "0e894f8b-569c-45ae-bcec-257200d23c63" },
                    { "70d82cd8-8910-4447-af13-caddf6a1f55b", "Refresh Permissions", "ADMIN_AUTHORIZATION_PERMISSIONS_REFRESH", "5d3da4f1-95a7-4fc4-abac-df5f782f1e79" },
                    { "7ae52279-9c38-4f0b-a1f1-e401db327816", "Refresh Permission Definitions", "ADMIN_AUTHORIZATION_PERMISSION_DEFINITIONS_REFRESH", "0e894f8b-569c-45ae-bcec-257200d23c63" },
                    { "8347ac9a-2b9a-4b03-9cb5-3855adc46355", "Change Permission Status", "ADMIN_AUTHORIZATION_PERMISSION_STATUS_CHANGE", "5d3da4f1-95a7-4fc4-abac-df5f782f1e79" },
                    { "a3455235-c9b3-4e67-b3ae-aacf6751295d", "Create Permission Definition", "ADMIN_AUTHORIZATION_PERMISSION_DEFINITION_CREATE", "0e894f8b-569c-45ae-bcec-257200d23c63" },
                    { "cb42ac4b-1daa-4f7c-856c-2af6603473e5", "Update Permission Definition", "ADMIN_AUTHORIZATION_PERMISSION_DEFINITION_UPDATE", "0e894f8b-569c-45ae-bcec-257200d23c63" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "DisplayName", "IsGranted", "Name", "ParentPermissionId", "PermissionDefinitionId", "RoleId" },
                values: new object[,]
                {
                    { "0dd2e45e-0362-4672-a475-1e0b9912d130", "Permission", true, "ADMIN_AUTHORIZATION_PERMISSION", "d4cc9401-ca88-4de3-941d-c5b2c1b960f4", "5d3da4f1-95a7-4fc4-abac-df5f782f1e79", "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" },
                    { "8fbbd082-aa86-4383-998c-c638d48164d1", "Change Permission Status", true, "ADMIN_AUTHORIZATION_PERMISSION_STATUS_CHANGE", "0dd2e45e-0362-4672-a475-1e0b9912d130", "8347ac9a-2b9a-4b03-9cb5-3855adc46355", "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" }
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
                name: "ConfirmRequests");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PasswordRequests");

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
