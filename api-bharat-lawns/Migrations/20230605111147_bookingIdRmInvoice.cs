using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class bookingIdRmInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Bookings_BookingId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_BookingId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17a92978-e92c-470f-bac3-63ca868ad1e7", "AQAAAAIAAYagAAAAEMGZI0mBQLVwVeHPUgHS6Caz/c6STFUTAGY3lT5n1FujYGAr0l8BPhbMQtPW1ZdwYQ==", "63ed7b4f-35a8-4b04-9694-424470d840b7" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_InvoiceId",
                table: "Bookings",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Invoices_InvoiceId",
                table: "Bookings",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Invoices_InvoiceId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_InvoiceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8478bac9-fa3a-4951-8659-1f8d39d402a4", "AQAAAAEAACcQAAAAEH8XqFnFFOYlL6CTEdeHsmlg1rio8tYszEfixua7aUlOO+yxqRIcZ75/sXdyjlwM6A==", "d91a5ad3-9dc1-4557-a501-b3908830b000" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BookingId",
                table: "Invoices",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Bookings_BookingId",
                table: "Invoices",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
