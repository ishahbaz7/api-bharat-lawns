using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class bookings_in_features : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Bookings_BookingId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_BookingId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Features");

            migrationBuilder.CreateTable(
                name: "BookingFeature",
                columns: table => new
                {
                    BookingsId = table.Column<int>(type: "int", nullable: false),
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingFeature", x => new { x.BookingsId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_BookingFeature_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingFeature_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "faeb5cc4-1021-4091-8524-f875b97352cc", "AQAAAAEAACcQAAAAEN7e/kaKyHL+Q3xHFQasfUOiehTVOOvY1aco4LNlSzC8M1OIWo70TVm9UQILmxwehw==", "f77f62ff-f90e-4b48-96c7-8969890eca8f" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingFeature_FeaturesId",
                table: "BookingFeature",
                column: "FeaturesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingFeature");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Bookings_BookingId",
                table: "Features",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
