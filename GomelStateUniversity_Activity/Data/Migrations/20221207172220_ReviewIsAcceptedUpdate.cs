using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class ReviewIsAcceptedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Reviews",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Reviews");
        }
    }
}
