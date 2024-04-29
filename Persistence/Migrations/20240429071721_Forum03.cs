using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Headings");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Headings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid", "UserName" },
                values: new object[] { new DateTime(2024, 4, 29, 10, 17, 21, 229, DateTimeKind.Local).AddTicks(3389), new DateTime(2024, 4, 29, 10, 17, 21, 229, DateTimeKind.Local).AddTicks(3402), "0a012e7c-5fa0-462b-93e2-af4a49931b66", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Headings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Headings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid", "UserId" },
                values: new object[] { new DateTime(2024, 4, 29, 0, 44, 6, 591, DateTimeKind.Local).AddTicks(8159), new DateTime(2024, 4, 29, 0, 44, 6, 591, DateTimeKind.Local).AddTicks(8174), "22ec9650-302c-47cc-a351-f3a8360c0e7e", null });
        }
    }
}
