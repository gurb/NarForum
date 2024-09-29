using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsChanged = table.Column<bool>(type: "boolean", nullable: false),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRequests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44483479-5b58-4b78-a5b4-16ed91a625e6", "AQAAAAIAAYagAAAAEF2Yif8jxzv6/QjQW1f0FHzT9NXCwgMgXbtaGnyMz5vX7crKhWf6r7ClfxwYoVKjVw==", "3f2f156e-7f44-4ecc-865d-88be366b8a4c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44a76992-ad9f-4f7d-9e92-20b6974a8e11", "AQAAAAIAAYagAAAAEJUvLlMCaTgX9NaFg2UrfWUPTOU8lTnKrKjt/T3wbauoeoXZDvlHZz/I2EOZjX5PzA==", "c654baa4-2eed-4ee1-92f0-ac752a06ea46" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "988bfb0a-b638-41be-b1b2-0b861f7c1047", "AQAAAAIAAYagAAAAEFnino/jbDe3MYczgECq1YCU/QuNceA7hhPfHN1MtJTQK1VVhaprIy3gu3dGKE7esw==", "1f2b29a4-3960-4601-a9dd-ef435a03bbc5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmRequests");

            migrationBuilder.DropTable(
                name: "PasswordRequests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5b9617b-0ae0-4cd8-9b10-8fbe56357ff1", "AQAAAAIAAYagAAAAEN02Y/wGQE704u7N+tAA704SQrTriOZpa7yI0MKuVUnVHD8ckPzYfT8Io2sncTFQBQ==", "c6083b97-d382-4e58-bbaa-1f0c722cac9a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca02524-80b8-4b62-b571-18d6af403af6", "AQAAAAIAAYagAAAAEPEN1P/UBEjqSzq1dAklm0ARoL5su5+83LdGrRWscg4uHQkPNxGbgiUpnJuue0oTkA==", "c355db49-1019-4522-a874-ddc717004d66" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e687b8bc-e145-45cc-952c-a14d656c1059", "AQAAAAIAAYagAAAAEEYFH/TteGLdrgsXESMJzg9NZMNRZf2R7abg236LCcgQvnK9Y0aw8fgNAXuY3I2vbw==", "8aad42db-aebf-43da-9492-14ff2c9f5ce3" });
        }
    }
}
