using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_bharat_lawns.Migrations
{
    public partial class assign_role_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0553d90e-03ee-48ce-9bed-3808d0c53345", "49b8420d-f99b-4530-8d27-6fcd0bbf4321" },
                    { "f4b56fbb-b881-4e61-a118-ea3946ca8d40", "cde5cf9f-fb79-4e1e-8afb-37c58cf6885a" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b8420d-f99b-4530-8d27-6fcd0bbf4321",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1863b54-8ba7-4d2f-aac5-d0e5e779d0c1", "AQAAAAEAACcQAAAAEJnRU8y/VKIxcI0dM8T9z3jlNLi4WCxufQYIX5ZOwwFhSwa/PeWnG65niYsy6DSevg==", "c71bfa97-9ee0-4bc8-b7a3-154d52abf031" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cde5cf9f-fb79-4e1e-8afb-37c58cf6885a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae667577-00ab-4d82-b61c-b57dfd03f0de", "AQAAAAEAACcQAAAAEL3vQtKfFrV+zyztr5cpvhE01pArcBBBl6mcJ2FOed649hpy+xYvvxnIass23s+FNA==", "809f9106-b041-45a8-b34e-be05164db328" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e91ac8b6-d5c9-43fa-9f1b-a60ee036ff7b", "AQAAAAEAACcQAAAAECl9sU24M1AoRYth3rjCtukLTW+Qbqdu3VVSzIBx9YtlNBnesVKzqqeZEvyDoXHmIw==", "0e08e47b-c8f6-45c1-8a58-2b0c96a5764c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0553d90e-03ee-48ce-9bed-3808d0c53345", "49b8420d-f99b-4530-8d27-6fcd0bbf4321" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f4b56fbb-b881-4e61-a118-ea3946ca8d40", "cde5cf9f-fb79-4e1e-8afb-37c58cf6885a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49b8420d-f99b-4530-8d27-6fcd0bbf4321",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce23f35a-3274-4b17-ad99-bb0ab5de4ef1", "AQAAAAEAACcQAAAAEJv+uBEnYPBHf5ujce7CE/QIydfJrnFj/LCM144J1SOLpbDsk0JI7NpUkv+0i8WJmA==", "5cb20a56-960e-4825-9d05-ab83b6223d53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cde5cf9f-fb79-4e1e-8afb-37c58cf6885a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f6ba641-65d3-4091-85ca-bd877fe504ec", "AQAAAAEAACcQAAAAEJokeKpNBtWLXM3XqU9F/Qo15W1t+09zo9ksi7eo5Qyp30Vk2H/HRV3h1jjJIjKSsg==", "70a3ce44-dcfe-480e-abdf-e26660e325a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef20c48e-3b60-44d7-bc9f-3b5973679bfb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d303cebd-cf08-49a5-af1f-639da5166dc2", "AQAAAAEAACcQAAAAEDsz1JbUcfBLI4tJYWzepi367fUsYIHPwYuWBKXfnMD8SsATN8miqvXP2gn0mGp2vg==", "a1f742e3-e05a-468e-98a2-f9c35631dd80" });
        }
    }
}
