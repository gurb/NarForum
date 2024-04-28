using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOnlineTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Description", "LastOnlineTime", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "14a12f27-7f36-4630-b50b-a1f5e6b39bcf", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEMARjKVms82gxLIxnQ85np4pfe4KHaHH6tX8Vw5rj3Tf4HD1tLytIeejio5pvpieSQ==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "134cbd7e-76ae-468d-b1e3-4197c5564b3d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Description", "LastOnlineTime", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "1867b390-3b0b-4502-aed5-cfda92e97c49", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEKHE2lw9ZiIb16MKVJ41h+Kk/3FUMWRgjesKymX5ybtvcJQo8W+QM4XkJNmnCXi2MQ==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3208b89d-6696-4c3b-919d-5b32b5590acf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastOnlineTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7ccc83b-bc9b-4482-8fdf-a211af171a3b", "AQAAAAIAAYagAAAAEEV3hid922FgmTItEm5ED6r1RemGStmJ4z1reXDjWKgDAxXuJCrFslyH/DQBOGat0g==", "90d322a7-0334-4b44-af5d-af5ded615d22" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "def064a9-2d87-4501-b29b-df6430fe590b", "AQAAAAIAAYagAAAAEIyVdnjVqi/hER3SBNvMqj5Ng8hqESe4eqL2TFChMIvCqhCtNHXWsCr4N8Md/n0Jow==", "346f563f-271c-4ae3-bcaf-f4b84df9becb" });
        }
    }
}
