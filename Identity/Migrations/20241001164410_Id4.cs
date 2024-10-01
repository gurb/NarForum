using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "PermissionDefinitions",
                columns: new[] { "Id", "DisplayName", "Name", "ParentPermissionDefinitionId" },
                values: new object[,]
                {
                    { "3b68baff-2a60-4899-9e04-e66d7885de41", "Pin Heading", "FORUM_HEADING_PIN", "336e4081-f40d-4e45-bcc5-adb0c04d016f" },
                    { "b79b4860-25b1-44cd-8d74-9c46f0f308c6", "Lock Heading", "FORUM_HEADING_LOCK", "336e4081-f40d-4e45-bcc5-adb0c04d016f" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Rank", "RegisterDate", "Role", "SecurityStamp" },
                values: new object[] { "087e67aa-08e8-499a-8979-cb42246fec18", "AQAAAAIAAYagAAAAEFc/bMKs4hUITETzwzJQjO02jua3UUlzBn2LclDKNT3mX5WM6Gi6gVe2EDgkp2NQ7A==", null, new DateTime(2024, 10, 1, 16, 44, 9, 595, DateTimeKind.Utc).AddTicks(589), null, "64af9a85-ee47-4087-ba5e-d6602208281d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Rank", "RegisterDate", "Role", "SecurityStamp" },
                values: new object[] { "6a04c350-5669-4ba0-802b-6f6e52e85467", "AQAAAAIAAYagAAAAEMZqAngZPeJzrV3Ofocwp9AXZOj8LwWEei0M1EJB6Qt91Le7G+me6NaeIz5qNi856A==", null, new DateTime(2024, 10, 1, 16, 44, 9, 432, DateTimeKind.Utc).AddTicks(524), null, "4a5ba304-b8cf-4271-9245-095e4f18ade8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Rank", "RegisterDate", "Role", "SecurityStamp" },
                values: new object[] { "bb16eebc-979f-480d-8280-1353bf4d8381", "AQAAAAIAAYagAAAAEOvPqCUrFZAVgYK7bZ+lIbW5JHsZ3gCjPKSYTkC5Wiqm3+iA8NKfWoIof2OIPvdUcw==", null, new DateTime(2024, 10, 1, 16, 44, 9, 509, DateTimeKind.Utc).AddTicks(9768), null, "f2b1648a-ee5e-4311-8952-ebceb99a4c92" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionDefinitions",
                keyColumn: "Id",
                keyValue: "3b68baff-2a60-4899-9e04-e66d7885de41");

            migrationBuilder.DeleteData(
                table: "PermissionDefinitions",
                keyColumn: "Id",
                keyValue: "b79b4860-25b1-44cd-8d74-9c46f0f308c6");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "44483479-5b58-4b78-a5b4-16ed91a625e6", "AQAAAAIAAYagAAAAEF2Yif8jxzv6/QjQW1f0FHzT9NXCwgMgXbtaGnyMz5vX7crKhWf6r7ClfxwYoVKjVw==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f2f156e-7f44-4ecc-865d-88be366b8a4c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "44a76992-ad9f-4f7d-9e92-20b6974a8e11", "AQAAAAIAAYagAAAAEJUvLlMCaTgX9NaFg2UrfWUPTOU8lTnKrKjt/T3wbauoeoXZDvlHZz/I2EOZjX5PzA==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c654baa4-2eed-4ee1-92f0-ac752a06ea46" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "988bfb0a-b638-41be-b1b2-0b861f7c1047", "AQAAAAIAAYagAAAAEFnino/jbDe3MYczgECq1YCU/QuNceA7hhPfHN1MtJTQK1VVhaprIy3gu3dGKE7esw==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1f2b29a4-3960-4601-a9dd-ef435a03bbc5" });
        }
    }
}
