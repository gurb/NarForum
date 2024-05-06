using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveDate",
                table: "Headings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastPostId",
                table: "Headings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUserName",
                table: "Headings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastHeadingId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastPostId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastUserName",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 6, 6, 42, 55, 46, DateTimeKind.Utc).AddTicks(7322), new DateTime(2024, 5, 6, 6, 42, 55, 46, DateTimeKind.Utc).AddTicks(7328), "cbb7e965-36fa-47a5-aa73-27aae81bb080" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveDate",
                table: "Headings");

            migrationBuilder.DropColumn(
                name: "LastPostId",
                table: "Headings");

            migrationBuilder.DropColumn(
                name: "LastUserName",
                table: "Headings");

            migrationBuilder.DropColumn(
                name: "LastHeadingId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastPostId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastUserName",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 5, 10, 15, 43, 639, DateTimeKind.Utc).AddTicks(1985), new DateTime(2024, 5, 5, 10, 15, 43, 639, DateTimeKind.Utc).AddTicks(1991), "a4d3fe77-56e6-48cd-ba30-4b4f4f6e06c7" });
        }
    }
}
