using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainPostId",
                table: "Headings",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MainPostId",
                table: "Headings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Headings");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 4, 25, 10, 22, 52, 934, DateTimeKind.Local).AddTicks(1487), new DateTime(2024, 4, 25, 10, 22, 52, 934, DateTimeKind.Local).AddTicks(1500), "b88527ce-ed1f-48ae-a1d3-28e0e41f54d5" });
        }
    }
}
