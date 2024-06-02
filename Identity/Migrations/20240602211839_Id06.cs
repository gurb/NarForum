using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGranted = table.Column<bool>(type: "bit", nullable: false),
                    ParentPermissionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
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


            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bac43a5e-f7bb-4448-b12f-1add431ccbbf", null, "Moderator", "MODERATOR" },
                    { "dac42a6e-f7bb-4448-b3cf-1add431ccbbf", null, "Member", "MEMBER" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", null, "Admin", "ADMIN" }
                });

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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "IsGranted", "Name", "ParentPermissionId", "RoleId" },
                values: new object[,]
                {
                    { "0c125c40-7d4e-41de-a00f-c9748142d35a", true, "FORUM_CAN_OPEN_HEADING", null, "bac43a5e-f7bb-4448-b12f-1add431ccbbf" },
                    { "9519adb7-9611-40bc-bd8e-2d71b5097755", true, "FORUM_CAN_OPEN_HEADING", null, "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },
                    { "a0737557-3282-45eb-b8ed-daa1cc2bc924", true, "FORUM_PROFILE_PAGE", null, "bac43a5e-f7bb-4448-b12f-1add431ccbbf" },
                    { "b426d1e0-4afe-4752-abb1-444f593ca9d3", true, "FORUM_CAN_REPLY", null, "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },
                    { "dc9aff7b-7de7-4ef3-90a1-047f8ef935f4", true, "FORUM_PROFILE_PAGE", null, "dac42a6e-f7bb-4448-b3cf-1add431ccbbf" },
                    { "f46684f5-6513-4a7d-bbdd-0e43a395a38c", true, "FORUM_CAN_REPLY", null, "bac43a5e-f7bb-4448-b12f-1add431ccbbf" },
                    { "25315678-0f4a-4a38-b82c-83a130ac4992", true, "FORUM_CAN_OPEN_HEADING", null, "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" },
                    { "532be471-dd63-4a39-ba2a-4fdc31dc432b", true, "FORUM_PROFILE_PAGE", null, "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" },
                    { "e87f7d83-721e-4e3d-84c4-9b7f48215a84", true, "FORUM_CAN_REPLY", null, "cbc43a8e-f7bb-4445-baaf-1add431ffbbf" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentPermissionId",
                table: "Permissions",
                column: "ParentPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bac43a5e-f7bb-4448-b12f-1add431ccbbf");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dac42a6e-f7bb-4448-b3cf-1add431ccbbf");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", null, "Employee", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cda5be96-0b20-4505-990d-6d965c6689d5", "AQAAAAIAAYagAAAAEN/XYE+d0fpe4gG4/DotEN3aX7paMh+jN9YXkaJoxKw1AhBeBk5EfehCumm/5SMr3A==", "d56146c5-a6a1-45c7-b231-960aeadac760" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f16bb09b-93d9-4347-bb92-d42b9a67c29f", "AQAAAAIAAYagAAAAEG0N52RELJAV6c1TYep/1FB6gYwBa2D+LXLDEU3UA1LXyBvJkcOlxZyBbcakoZuHwQ==", "4a9c28a4-c65e-46c9-9d6e-613842a50045" });
        }
    }
}
