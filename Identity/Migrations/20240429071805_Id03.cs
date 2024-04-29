using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Id03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05004f5e-4219-4a1d-bc90-64fd7b24cf55", "AQAAAAIAAYagAAAAEJ9VCFTnMPk0Ah4u2RJp0aH1/9XTvYCPD+dvu+WL4Za01SRxbctOIVWB3ANQRjKDMw==", "e47d3fe5-89c7-4344-be9f-cdc63a427a46" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "219ed49e-112f-4f59-aff7-003186cac79f", "AQAAAAIAAYagAAAAEN9SuLA1bJP26Q0lwVA+J8oeIkrhaF1rZO9ssm+pOyySuRXDw5G5EfPPuoOvs38bIQ==", "68fc7248-c2bc-4978-9403-e35ed5dfbaf5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14a12f27-7f36-4630-b50b-a1f5e6b39bcf", "AQAAAAIAAYagAAAAEMARjKVms82gxLIxnQ85np4pfe4KHaHH6tX8Vw5rj3Tf4HD1tLytIeejio5pvpieSQ==", "134cbd7e-76ae-468d-b1e3-4197c5564b3d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1867b390-3b0b-4502-aed5-cfda92e97c49", "AQAAAAIAAYagAAAAEKHE2lw9ZiIb16MKVJ41h+Kk/3FUMWRgjesKymX5ybtvcJQo8W+QM4XkJNmnCXi2MQ==", "3208b89d-6696-4c3b-919d-5b32b5590acf" });
        }
    }
}
