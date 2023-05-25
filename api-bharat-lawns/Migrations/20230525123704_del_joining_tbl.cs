using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class del_joining_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedFeatures");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e1d60b3-bb2b-498f-bb9c-6eda017c1048", "AQAAAAEAACcQAAAAEK7HAMQVLL8VyTJnHR6+lo+trkuJsOSlk92Uibgyzc1pVa7BM5GbXWedCcmNJ9anSQ==", "ec2c3c60-5d3b-4e7a-86b9-847db6b44add" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookedFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookedFeatures_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
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
                name: "IX_BookedFeatures_BookingId",
                table: "BookedFeatures",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedFeatures_FeatureId",
                table: "BookedFeatures",
                column: "FeatureId");
        }
    }
}
