using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Forum13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLock",
                table: "Headings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    QuotePostId = table.Column<int>(type: "int", nullable: true),
                    SGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotes_Posts_QuotePostId",
                        column: x => x.QuotePostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    ReplyPostId = table.Column<int>(type: "int", nullable: true),
                    SGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Posts_ReplyPostId",
                        column: x => x.ReplyPostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 9, 13, 32, 35, 488, DateTimeKind.Utc).AddTicks(3762), new DateTime(2024, 5, 9, 13, 32, 35, 488, DateTimeKind.Utc).AddTicks(3768), "47420f94-a0cd-45dd-9ef5-2b9ca6905420" });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_PostId",
                table: "Quotes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuotePostId",
                table: "Quotes",
                column: "QuotePostId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_PostId",
                table: "Replies",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ReplyPostId",
                table: "Replies",
                column: "ReplyPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropColumn(
                name: "IsLock",
                table: "Headings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate", "SGuid" },
                values: new object[] { new DateTime(2024, 5, 7, 12, 31, 22, 660, DateTimeKind.Utc).AddTicks(3351), new DateTime(2024, 5, 7, 12, 31, 22, 660, DateTimeKind.Utc).AddTicks(3356), "e8ad2e09-0018-4fa6-86bf-1b38e63bb7b6" });
        }
    }
}
