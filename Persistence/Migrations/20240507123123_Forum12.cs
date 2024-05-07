using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 7, 12, 31, 22, 660, DateTimeKind.Utc).AddTicks(3351), new DateTime(2024, 5, 7, 12, 31, 22, 660, DateTimeKind.Utc).AddTicks(3356), "e8ad2e09-0018-4fa6-86bf-1b38e63bb7b6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserName",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 7, 11, 27, 37, 728, DateTimeKind.Utc).AddTicks(6543), new DateTime(2024, 5, 7, 11, 27, 37, 728, DateTimeKind.Utc).AddTicks(6547), "10dfd5f3-99a4-49db-9b60-0ba4b6f72524" });
        }
    }
}
