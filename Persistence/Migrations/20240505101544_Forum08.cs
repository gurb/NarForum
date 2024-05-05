using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostCounter",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 5, 10, 15, 43, 639, DateTimeKind.Utc).AddTicks(1985), new DateTime(2024, 5, 5, 10, 15, 43, 639, DateTimeKind.Utc).AddTicks(1991), "a4d3fe77-56e6-48cd-ba30-4b4f4f6e06c7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostCounter",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 4, 8, 6, 13, 589, DateTimeKind.Utc).AddTicks(2073), new DateTime(2024, 5, 4, 8, 6, 13, 589, DateTimeKind.Utc).AddTicks(2080), "352c428d-3950-452a-ab9f-75a65a528162" });
        }
    }
}
