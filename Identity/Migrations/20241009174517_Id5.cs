using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeadingCounter",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostCounter",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                columns: new[] { "ConcurrencyStamp", "HeadingCounter", "PasswordHash", "PostCounter", "RegisterDate", "SecurityStamp" },
                values: new object[] { "dff4b347-d535-4e33-a66e-bc91382f97e5", 0, "AQAAAAIAAYagAAAAELbvQ8xCujENM98GP3bOLz+JlKWtZbiMHhx3k7Xy0vh1XcqIY9ZfiWZXn9GK8ZDOLQ==", 0, new DateTime(2024, 10, 9, 17, 45, 16, 910, DateTimeKind.Utc).AddTicks(3405), "cb5a05e3-dacc-4138-acf3-5a40a8eb1550" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "HeadingCounter", "PasswordHash", "PostCounter", "RegisterDate", "SecurityStamp" },
                values: new object[] { "88b447e4-4dec-44e0-8ca1-8a81df0fd83a", 0, "AQAAAAIAAYagAAAAENQqemrlB+Nks7rTd6X3sN+QVVtcsHW6tCpFvxq1rqb1UzFgrcTXROG0vkCMdo+X7w==", 0, new DateTime(2024, 10, 9, 17, 45, 16, 781, DateTimeKind.Utc).AddTicks(9235), "e0e2d746-7f2a-4b49-ba2c-2423e8ddf91e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "HeadingCounter", "PasswordHash", "PostCounter", "RegisterDate", "SecurityStamp" },
                values: new object[] { "99337141-2459-4b57-ba9f-eece71ca3dfb", 0, "AQAAAAIAAYagAAAAENoPCppTVIwEkQwkVwoGWl9QcSKpKelrX7+ofmlMHf2dHg0vb7Tr/Ytxf8WZwZKn6A==", 0, new DateTime(2024, 10, 9, 17, 45, 16, 845, DateTimeKind.Utc).AddTicks(7595), "d87a1426-0fd8-4162-a19c-0a9adf7b64d7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadingCounter",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostCounter",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "076f24af-8934-4bf2-8d4e-03a5b48db4f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "087e67aa-08e8-499a-8979-cb42246fec18", "AQAAAAIAAYagAAAAEFc/bMKs4hUITETzwzJQjO02jua3UUlzBn2LclDKNT3mX5WM6Gi6gVe2EDgkp2NQ7A==", new DateTime(2024, 10, 1, 16, 44, 9, 595, DateTimeKind.Utc).AddTicks(589), "64af9a85-ee47-4087-ba5e-d6602208281d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "6a04c350-5669-4ba0-802b-6f6e52e85467", "AQAAAAIAAYagAAAAEMZqAngZPeJzrV3Ofocwp9AXZOj8LwWEei0M1EJB6Qt91Le7G+me6NaeIz5qNi856A==", new DateTime(2024, 10, 1, 16, 44, 9, 432, DateTimeKind.Utc).AddTicks(524), "4a5ba304-b8cf-4271-9245-095e4f18ade8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterDate", "SecurityStamp" },
                values: new object[] { "bb16eebc-979f-480d-8280-1353bf4d8381", "AQAAAAIAAYagAAAAEOvPqCUrFZAVgYK7bZ+lIbW5JHsZ3gCjPKSYTkC5Wiqm3+iA8NKfWoIof2OIPvdUcw==", new DateTime(2024, 10, 1, 16, 44, 9, 509, DateTimeKind.Utc).AddTicks(9768), "f2b1648a-ee5e-4311-8952-ebceb99a4c92" });
        }
    }
}
