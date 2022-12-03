using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class AdminAccountData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "Group", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronym", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[] { "e9c84823-8e52-4bce-aeab-5c3435059c5c", 0, "23d875e1-2d80-4905-a52d-8584ecb37f37", null, false, null, null, false, null, null, null, "ADMINISTRATOR", "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==", null, null, false, "d434d335-e0c7-4433-b3b7-3dfba101a15f", null, false, "Administrator", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "e9c84823-8e52-4bce-aeab-5c3435059c5c", "6aedd11d-510d-4017-b685-1c6b6fa92b91" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e9c84823-8e52-4bce-aeab-5c3435059c5c", "6aedd11d-510d-4017-b685-1c6b6fa92b91" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9c84823-8e52-4bce-aeab-5c3435059c5c");
        }
    }
}
