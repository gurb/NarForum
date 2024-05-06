using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastUserName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 6, 6, 57, 57, 853, DateTimeKind.Utc).AddTicks(7642), new DateTime(2024, 5, 6, 6, 57, 57, 853, DateTimeKind.Utc).AddTicks(7647), "c6451e25-80e2-4818-82d8-5ac12f96d09a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveDate",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "LastUserName",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 6, 6, 42, 55, 46, DateTimeKind.Utc).AddTicks(7322), new DateTime(2024, 5, 6, 6, 42, 55, 46, DateTimeKind.Utc).AddTicks(7328), "cbb7e965-36fa-47a5-aa73-27aae81bb080" });
        }
    }
}
