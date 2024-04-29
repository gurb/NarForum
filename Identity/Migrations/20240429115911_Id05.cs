using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "cda5be96-0b20-4505-990d-6d965c6689d5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEN/XYE+d0fpe4gG4/DotEN3aX7paMh+jN9YXkaJoxKw1AhBeBk5EfehCumm/5SMr3A==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d56146c5-a6a1-45c7-b231-960aeadac760" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "LastOnlineTime", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "f16bb09b-93d9-4347-bb92-d42b9a67c29f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEG0N52RELJAV6c1TYep/1FB6gYwBa2D+LXLDEU3UA1LXyBvJkcOlxZyBbcakoZuHwQ==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4a9c28a4-c65e-46c9-9d6e-613842a50045" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
