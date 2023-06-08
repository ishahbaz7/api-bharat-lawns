using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class static_role_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0553d90e-03ee-48ce-9bed-3808d0c53345", "3808d0c53345", "booking_role", "BOOKING_ROLE" },
                    { "f4b56fbb-b881-4e61-a118-ea3946ca8d40", "ea3946ca8d40", "reports_role", "REPORTS_ROLE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d303cebd-cf08-49a5-af1f-639da5166dc2", "AQAAAAEAACcQAAAAEDsz1JbUcfBLI4tJYWzepi367fUsYIHPwYuWBKXfnMD8SsATN8miqvXP2gn0mGp2vg==", "a1f742e3-e05a-468e-98a2-f9c35631dd80" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "49b8420d-f99b-4530-8d27-6fcd0bbf4321", 0, "ce23f35a-3274-4b17-ad99-bb0ab5de4ef1", "AppUser", null, false, false, null, "Booking User", null, "BL-BOOKING", "AQAAAAEAACcQAAAAEJv+uBEnYPBHf5ujce7CE/QIydfJrnFj/LCM144J1SOLpbDsk0JI7NpUkv+0i8WJmA==", null, false, "5cb20a56-960e-4825-9d05-ab83b6223d53", false, "bl-booking" },
                    { "cde5cf9f-fb79-4e1e-8afb-37c58cf6885a", 0, "8f6ba641-65d3-4091-85ca-bd877fe504ec", "AppUser", null, false, false, null, "Reports User", null, "BL-REPORTS", "AQAAAAEAACcQAAAAEJokeKpNBtWLXM3XqU9F/Qo15W1t+09zo9ksi7eo5Qyp30Vk2H/HRV3h1jjJIjKSsg==", null, false, "70a3ce44-dcfe-480e-abdf-e26660e325a1", false, "bl-reports" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0553d90e-03ee-48ce-9bed-3808d0c53345");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b56fbb-b881-4e61-a118-ea3946ca8d40");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b8420d-f99b-4530-8d27-6fcd0bbf4321");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cde5cf9f-fb79-4e1e-8afb-37c58cf6885a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17a92978-e92c-470f-bac3-63ca868ad1e7", "AQAAAAIAAYagAAAAEMGZI0mBQLVwVeHPUgHS6Caz/c6STFUTAGY3lT5n1FujYGAr0l8BPhbMQtPW1ZdwYQ==", "63ed7b4f-35a8-4b04-9694-424470d840b7" });
        }
    }
}
