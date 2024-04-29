using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "RegisterDate",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastOnlineTime",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "LastOnlineTime", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f4371935-3a9a-4543-81dd-c5e3bdb08f25", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEK0TpeSTZeZG56E7o/jXcw+s6xogcuRHf7zF8eIeJqQ4FaCV6EDWtOba8mo0ZBTiJw==", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "9b199e7d-b7cf-4e98-bcd3-7b8f9610615f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "LastOnlineTime", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "dbb51b91-74f0-4ded-8772-3ec956ba82bb", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "AQAAAAIAAYagAAAAEHSxRi9CVeut8FKNnV4RyvbxmpVY+YXukEagQAYxYpQ8XVozqOyk41zQF3RBwJWh6g==", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "c98d276a-5b59-4c62-948a-e661cf5ad763" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastOnlineTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "LastOnlineTime", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "05004f5e-4219-4a1d-bc90-64fd7b24cf55", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEJ9VCFTnMPk0Ah4u2RJp0aH1/9XTvYCPD+dvu+WL4Za01SRxbctOIVWB3ANQRjKDMw==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e47d3fe5-89c7-4344-be9f-cdc63a427a46" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "LastOnlineTime", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "219ed49e-112f-4f59-aff7-003186cac79f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEN9SuLA1bJP26Q0lwVA+J8oeIkrhaF1rZO9ssm+pOyySuRXDw5G5EfPPuoOvs38bIQ==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "68fc7248-c2bc-4978-9403-e35ed5dfbaf5" });
        }
    }
}
