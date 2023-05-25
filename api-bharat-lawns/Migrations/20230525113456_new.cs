using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "724f01e3-afd1-4b0a-8263-91adb14cea03", "AQAAAAEAACcQAAAAEIciQJQFOWHbqDGhs2ByU5B7nDjWLnX3sj8skJFmy9r3kjREN2AheLQYFu9MqcnOPg==", "9075fe71-fae6-4ac7-961d-88a14296daa8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79181e92-7d7f-4e5e-bd88-a99b33861b9b", "AQAAAAEAACcQAAAAEA7l9XTPQ0sZaI1yVgAxWHC5USpGNOkLY8SpGE1yuKvEhIW2zO7YO5zIwJr4MKZWnQ==", "22ccdc00-d772-420f-93ec-a1b34673206a" });
        }
    }
}
