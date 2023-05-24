using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class event_datetime_to_timeony : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedPrograms_Events_EventsId",
                table: "BookedPrograms");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "BookedPrograms",
                newName: "ProgramTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BookedPrograms_EventsId",
                table: "BookedPrograms",
                newName: "IX_BookedPrograms_ProgramTypeId");

            migrationBuilder.CreateTable(
                name: "ProgramTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfHours = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookedPrograms_ProgramTypes_ProgramTypeId",
                table: "BookedPrograms",
                column: "ProgramTypeId",
                principalTable: "ProgramTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedPrograms_ProgramTypes_ProgramTypeId",
                table: "BookedPrograms");

            migrationBuilder.DropTable(
                name: "ProgramTypes");

            migrationBuilder.RenameColumn(
                name: "ProgramTypeId",
                table: "BookedPrograms",
                newName: "EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_BookedPrograms_ProgramTypeId",
                table: "BookedPrograms",
                newName: "IX_BookedPrograms_EventsId");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookedPrograms_Events_EventsId",
                table: "BookedPrograms",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
