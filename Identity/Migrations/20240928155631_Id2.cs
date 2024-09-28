using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                columns: new[] { "ConcurrencyStamp", "IsBlocked", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5b9617b-0ae0-4cd8-9b10-8fbe56357ff1", false, "AQAAAAIAAYagAAAAEN02Y/wGQE704u7N+tAA704SQrTriOZpa7yI0MKuVUnVHD8ckPzYfT8Io2sncTFQBQ==", "c6083b97-d382-4e58-bbaa-1f0c722cac9a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "IsBlocked", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fca02524-80b8-4b62-b571-18d6af403af6", false, "AQAAAAIAAYagAAAAEPEN1P/UBEjqSzq1dAklm0ARoL5su5+83LdGrRWscg4uHQkPNxGbgiUpnJuue0oTkA==", "c355db49-1019-4522-a874-ddc717004d66" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "IsBlocked", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e687b8bc-e145-45cc-952c-a14d656c1059", false, "AQAAAAIAAYagAAAAEEYFH/TteGLdrgsXESMJzg9NZMNRZf2R7abg236LCcgQvnK9Y0aw8fgNAXuY3I2vbw==", "8aad42db-aebf-43da-9492-14ff2c9f5ce3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77f78c59-1a17-45c1-b187-feeaa9c5e03c", "AQAAAAIAAYagAAAAEF3hjNmv+ZUF2ffICTwVM1Ri0vQ0vg2f6c1swWKFRI755noQbI8sXYm09L6pLssmuQ==", "62744105-ec19-42c4-a922-20645d920bb3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ef52785-a905-4ca1-94f8-ebf748a077c6", "AQAAAAIAAYagAAAAEIXOc66Zunp/PXzJteZ/0XR8K2GrIjJ5zOJewDbbzW9CwBLHT+VP44UOXARWiKazkw==", "a4dbd94f-df7e-4c46-94df-ea323ca7071b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52e2eecf-f645-484b-a0b8-f722e446866e", "AQAAAAIAAYagAAAAEKVjstzDNwLQN+1L/sir3BK4PNyk8SlReGy9sSmXcLbHEVRL7on2qQ6tQ9AqhHcWjQ==", "39d8ed1e-ee08-4aa9-9a1b-ef733ed9e8fc" });
        }
    }
}
