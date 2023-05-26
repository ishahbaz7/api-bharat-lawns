using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class advance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Advance",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98ca96e7-91c7-4611-b947-b53df419a4a6", "AQAAAAEAACcQAAAAEMIprshJTQDEcX6PfFdbuDv2Qp3Rgv5e9CPpTwsX5r/sSK0E/lVE1Gd6rmLNoHe/SQ==", "e5bcfa14-6b64-4af1-bd57-4b02b557cc53" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advance",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e1d60b3-bb2b-498f-bb9c-6eda017c1048", "AQAAAAEAACcQAAAAEK7HAMQVLL8VyTJnHR6+lo+trkuJsOSlk92Uibgyzc1pVa7BM5GbXWedCcmNJ9anSQ==", "ec2c3c60-5d3b-4e7a-86b9-847db6b44add" });
        }
    }
}
