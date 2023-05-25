using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class features_in_bokings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38fcc3e2-5d6a-4952-9f5e-a033ed369495", "AQAAAAEAACcQAAAAEJgG8bwKflwLEIthuFo4cWDPP3ai26Ww78wqL3YTpQ9j2Jcd9eBXZp+ocA/YY8dYcw==", "0bff3a2d-421c-4a30-b054-dfedbada6b0d" });

            migrationBuilder.CreateIndex(
                name: "IX_Features_BookingId",
                table: "Features",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ProgramTypeId",
                table: "Bookings",
                column: "ProgramTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ProgramTypes_ProgramTypeId",
                table: "Bookings",
                column: "ProgramTypeId",
                principalTable: "ProgramTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Bookings_BookingId",
                table: "Features",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ProgramTypes_ProgramTypeId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Bookings_BookingId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_BookingId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ProgramTypeId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Features");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "724f01e3-afd1-4b0a-8263-91adb14cea03", "AQAAAAEAACcQAAAAEIciQJQFOWHbqDGhs2ByU5B7nDjWLnX3sj8skJFmy9r3kjREN2AheLQYFu9MqcnOPg==", "9075fe71-fae6-4ac7-961d-88a14296daa8" });
        }
    }
}
