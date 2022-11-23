using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class ScheduleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Subdivisions_SubdivisionId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_SubdivisionId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "SubdivisionId",
                table: "Schedule");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Schedule",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ApplicationUserId",
                table: "Schedule",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_AspNetUsers_ApplicationUserId",
                table: "Schedule",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_AspNetUsers_ApplicationUserId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_ApplicationUserId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Schedule");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Schedule",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubdivisionId",
                table: "Schedule",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SubdivisionId",
                table: "Schedule",
                column: "SubdivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Subdivisions_SubdivisionId",
                table: "Schedule",
                column: "SubdivisionId",
                principalTable: "Subdivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
