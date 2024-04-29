using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 29, 13, 56, 46, 61, DateTimeKind.Unspecified).AddTicks(2798), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 29, 13, 56, 46, 61, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 3, 0, 0, 0)), "e717e150-0d2b-4b4f-9846-45eb60009fcd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 29, 13, 55, 34, 835, DateTimeKind.Unspecified).AddTicks(9564), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 4, 29, 13, 55, 34, 835, DateTimeKind.Unspecified).AddTicks(9599), new TimeSpan(0, 3, 0, 0, 0)), "8a21ba01-0f62-4bd3-a6b7-363e0e1ec80e" });
        }
    }
}
