using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class invoiceNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceNo",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e8e3f2a-eb4e-4538-86c4-2836129cd7e9", "AQAAAAEAACcQAAAAEIiwj4/yNLHHNw9HkqN4jcf/0xgKmUYwZsb3tuZPPqbVsoZFlmehDfrQIvCFr6VaHw==", "0b6e7d50-23e1-4108-8e37-6c3554567935" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65b7f844-8d5a-4d9a-b0b9-614ed8d73936", "AQAAAAEAACcQAAAAEL/jW30wpuMkdrPyM1lWx8T/asyfR5lQ1BElcKh5rqh3uU573uoDeqWS+iM8929fqw==", "954da06b-8bc7-4bf5-831d-1bab42f33b57" });
        }
    }
}
