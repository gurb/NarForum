using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsVisibleForOwner = table.Column<bool>(type: "bit", nullable: false),
                    IsVisibleForReceiver = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "PermissionDefinitions",
                keyColumn: "Id",
                keyValue: "58b4d6c9-7db7-490b-b118-7fff4839fe69",
                column: "ParentPermissionDefinitionId",
                value: "efd0da20-755d-4dcb-a10f-617d84bc52aa");

            migrationBuilder.UpdateData(
                table: "PermissionDefinitions",
                keyColumn: "Id",
                keyValue: "8c87ab42-975a-4016-92a8-ec8e34852fbf",
                column: "ParentPermissionDefinitionId",
                value: "efd0da20-755d-4dcb-a10f-617d84bc52aa");

            migrationBuilder.UpdateData(
                table: "PermissionDefinitions",
                keyColumn: "Id",
                keyValue: "edae4f5c-d414-4753-b20c-7f6d32b8ed23",
                column: "ParentPermissionDefinitionId",
                value: "efd0da20-755d-4dcb-a10f-617d84bc52aa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9876f9c5-c106-4936-be52-3415b8a219db", "AQAAAAIAAYagAAAAEMaiPRyMZaZU5XOusj7IVImmIVCuVhj5fWMrdVG2rgQqQRWE5HqrFQuYE5OivZnk+Q==", "06a91c37-3dfa-4b2d-825e-e6db9abb1ca1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07d47cf3-c589-4f8d-a2b2-ff4d3d9e6abe", "AQAAAAIAAYagAAAAEBWluJi5OFTA6pTktbousKrRFzxBoNHkOKUYaK9LkPPk/hNgLndvSi60+95i9LLjUw==", "149bee35-15c5-4340-a7ba-6f1ebb5aa062" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_OwnerId",
                table: "Messages",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PermissionDefinitions",
                keyColumn: "Id",
                keyValue: "58b4d6c9-7db7-490b-b118-7fff4839fe69",
                column: "ParentPermissionDefinitionId",
                value: "95e10e0e-7e21-4a7c-849b-30a2e82a61b8");

            migrationBuilder.UpdateData(
                table: "PermissionDefinitions",
                keyColumn: "Id",
                keyValue: "8c87ab42-975a-4016-92a8-ec8e34852fbf",
                column: "ParentPermissionDefinitionId",
                value: "95e10e0e-7e21-4a7c-849b-30a2e82a61b8");

            migrationBuilder.UpdateData(
                table: "PermissionDefinitions",
                keyColumn: "Id",
                keyValue: "edae4f5c-d414-4753-b20c-7f6d32b8ed23",
                column: "ParentPermissionDefinitionId",
                value: "95e10e0e-7e21-4a7c-849b-30a2e82a61b8");

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
        }
    }
}
