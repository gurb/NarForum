using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostCounter",
                table: "Headings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadingCounter",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 4, 8, 6, 13, 589, DateTimeKind.Utc).AddTicks(2073), new DateTime(2024, 5, 4, 8, 6, 13, 589, DateTimeKind.Utc).AddTicks(2080), "352c428d-3950-452a-ab9f-75a65a528162" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostCounter",
                table: "Headings");

            migrationBuilder.DropColumn(
                name: "HeadingCounter",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 3, 14, 25, 52, 135, DateTimeKind.Utc).AddTicks(6717), new DateTime(2024, 5, 3, 14, 25, 52, 135, DateTimeKind.Utc).AddTicks(6723), "f827011c-7819-4e55-9898-dceabc887a50" });
        }
    }
}
