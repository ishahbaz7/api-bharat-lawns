using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class guest_role_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09ecccf8-35d3-431d-bdf2-0d491f3aa87c", "0d491f3aa87c", "guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac68b058-17e3-412a-a82a-b9246866691a", "AQAAAAEAACcQAAAAEKpdiVfcyxlXgh0ErE1C3VPmPJtgYbyxXYVYYDDY85xu8NFQcFXLLAua6bSJWemniA==", "74c005c7-ff6f-4e10-9572-681fa6003b9d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09ecccf8-35d3-431d-bdf2-0d491f3aa87c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32043d94-85aa-4c03-8ba0-4dc1b85bdf92", "AQAAAAEAACcQAAAAEGpRCenYLxYIK9SX0hJuIvbMzvLClMXoKSS7v0nu2cKx0migWW54trm77oNmypw2Qw==", "55661dbf-2d6a-4907-9ad5-cada7d27afa4" });
        }
    }
}
