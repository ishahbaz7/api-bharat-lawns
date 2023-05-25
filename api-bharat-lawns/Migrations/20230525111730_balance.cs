using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class balance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79181e92-7d7f-4e5e-bd88-a99b33861b9b", "AQAAAAEAACcQAAAAEA7l9XTPQ0sZaI1yVgAxWHC5USpGNOkLY8SpGE1yuKvEhIW2zO7YO5zIwJr4MKZWnQ==", "22ccdc00-d772-420f-93ec-a1b34673206a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6de92943-dc8a-4c8c-b951-c7c0498decf1", "AQAAAAEAACcQAAAAEI1C0B6msWldAmrlorubGYGkebCB8RzE4HvcAKPiVgf9b5gRzZfqfhZKqoRTr5Vwig==", "c01f52f2-2dd1-4827-8e0a-0b84d1bd4966" });
        }
    }
}
