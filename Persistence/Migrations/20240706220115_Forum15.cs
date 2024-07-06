using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "StaticPages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "StaticPages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "BlogPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "BlogPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 7, 6, 22, 1, 14, 644, DateTimeKind.Utc).AddTicks(4780), new DateTime(2024, 7, 6, 22, 1, 14, 644, DateTimeKind.Utc).AddTicks(4785), "eda33f44-2b5a-4137-893c-9c79bd8821f1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "StaticPages");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "StaticPages");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "BlogPosts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 7, 4, 21, 26, 47, 80, DateTimeKind.Utc).AddTicks(3859), new DateTime(2024, 7, 4, 21, 26, 47, 80, DateTimeKind.Utc).AddTicks(3864), "17c067cc-734c-49f8-8cdf-4cb5ee57f3f1" });
        }
    }
}
