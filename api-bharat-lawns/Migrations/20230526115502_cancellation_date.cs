using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class cancellation_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancellationDate",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65b7f844-8d5a-4d9a-b0b9-614ed8d73936", "AQAAAAEAACcQAAAAEL/jW30wpuMkdrPyM1lWx8T/asyfR5lQ1BElcKh5rqh3uU573uoDeqWS+iM8929fqw==", "954da06b-8bc7-4bf5-831d-1bab42f33b57" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellationDate",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98ca96e7-91c7-4611-b947-b53df419a4a6", "AQAAAAEAACcQAAAAEMIprshJTQDEcX6PfFdbuDv2Qp3Rgv5e9CPpTwsX5r/sSK0E/lVE1Gd6rmLNoHe/SQ==", "e5bcfa14-6b64-4af1-bd57-4b02b557cc53" });
        }
    }
}
