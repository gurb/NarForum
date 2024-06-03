using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermissionDefinitionId",
                table: "Permissions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "0c125c40-7d4e-41de-a00f-c9748142d35a",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "25315678-0f4a-4a38-b82c-83a130ac4992",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "532be471-dd63-4a39-ba2a-4fdc31dc432b",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "9519adb7-9611-40bc-bd8e-2d71b5097755",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "a0737557-3282-45eb-b8ed-daa1cc2bc924",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "b426d1e0-4afe-4752-abb1-444f593ca9d3",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "dc9aff7b-7de7-4ef3-90a1-047f8ef935f4",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "e87f7d83-721e-4e3d-84c4-9b7f48215a84",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "f46684f5-6513-4a7d-bbdd-0e43a395a38c",
                column: "PermissionDefinitionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa43be6c-a9fb-4c3a-86a5-d002c02fce2b", "AQAAAAIAAYagAAAAEHMREfHYkd2eGM7zsF8P5vPcEBHyttBas+RiCJvy3fBEAzUTBdn1AoKfWCr/PZ/1/A==", "8b4bddbb-bfc8-4039-8e6f-a0146f99eb22" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0161a9fc-f7e2-4ac3-a890-7df9a7644bcb", "AQAAAAIAAYagAAAAEI9EMb+JyTvF1U6MUNA6YaXBM2WNYaW0sghG0mhn6rRA6dRNZ2bqmuo6PxbLFXG5rg==", "36902398-e0b3-4934-8d90-a7d6638b9102" });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionDefinitionId",
                table: "Permissions",
                column: "PermissionDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_PermissionDefinitions_PermissionDefinitionId",
                table: "Permissions",
                column: "PermissionDefinitionId",
                principalTable: "PermissionDefinitions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_PermissionDefinitions_PermissionDefinitionId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_PermissionDefinitionId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "PermissionDefinitionId",
                table: "Permissions");

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
        }
    }
}
