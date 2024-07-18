using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAccept",
                table: "Chats",
                newName: "IsVisibleForReceiver");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisibleForCreator",
                table: "Chats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3db9938-5b64-4ccf-b662-6c7b93c89a63", "AQAAAAIAAYagAAAAEJ7bl3d3rv0uWnhrEBgOvX99boA7kK+0G3uaOY87oW5JvFqk6aIvZEqExbGV4aTb6w==", "56738014-fe89-4aed-aae0-0338545a6eee" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0915b002-b051-4ea1-857a-9dfcf26c72ed", "AQAAAAIAAYagAAAAEDDgSkxfePBaZEYsCwFOtfZ+LxA24Cj6a1FT0aX8y81C1uFlF+U5Zs5dr3J9v8YBhg==", "a61efff0-827c-43c3-857d-72e4087e9bde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisibleForCreator",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "IsVisibleForReceiver",
                table: "Chats",
                newName: "IsAccept");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6657109f-7b34-4f12-b924-da2a22fac1e1", "AQAAAAIAAYagAAAAEIhFt/EhNE/0hHigV/uYE79TkTIpMFP0diSGUGhlrQiZeH2q5N1gVv6XdGWNE4buuQ==", "220d6552-5b85-448a-b1cf-0e5c85e896fc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77f343bf-8e1a-4012-a165-9c4bec5f2c9b", "AQAAAAIAAYagAAAAEL/PAj5tpiLfdDfnqa3bEwarQpredIs8HMeRKf5ZVj8EeTIiZn1cL4OaLhxC09eSkw==", "47313686-60ae-4e80-9a05-945500cb39d7" });
        }
    }
}
