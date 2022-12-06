using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class ScheduleSubdivUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubdivisionId",
                table: "Schedule",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Subdivisions_SubdivisionId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_SubdivisionId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "SubdivisionId",
                table: "Schedule");
        }
    }
}
