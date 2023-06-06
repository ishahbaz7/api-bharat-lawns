using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class invNoInBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceNo",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8478bac9-fa3a-4951-8659-1f8d39d402a4", "AQAAAAEAACcQAAAAEH8XqFnFFOYlL6CTEdeHsmlg1rio8tYszEfixua7aUlOO+yxqRIcZ75/sXdyjlwM6A==", "d91a5ad3-9dc1-4557-a501-b3908830b000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e8e3f2a-eb4e-4538-86c4-2836129cd7e9", "AQAAAAEAACcQAAAAEIiwj4/yNLHHNw9HkqN4jcf/0xgKmUYwZsb3tuZPPqbVsoZFlmehDfrQIvCFr6VaHw==", "0b6e7d50-23e1-4108-8e37-6c3554567935" });
        }
    }
}
