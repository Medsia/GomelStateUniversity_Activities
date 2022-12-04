using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class ApplicationFormActivityTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationForms_Subdivisions_SubdivisionId",
                table: "ApplicationForms");

            migrationBuilder.AlterColumn<int>(
                name: "SubdivisionId",
                table: "ApplicationForms",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubdivisionActivityTypeId",
                table: "ApplicationForms",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "subdivisionActivityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Организатор ");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_SubdivisionActivityTypeId",
                table: "ApplicationForms",
                column: "SubdivisionActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationForms_subdivisionActivityTypes_SubdivisionActivityTypeId",
                table: "ApplicationForms",
                column: "SubdivisionActivityTypeId",
                principalTable: "subdivisionActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationForms_Subdivisions_SubdivisionId",
                table: "ApplicationForms",
                column: "SubdivisionId",
                principalTable: "Subdivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationForms_subdivisionActivityTypes_SubdivisionActivityTypeId",
                table: "ApplicationForms");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationForms_Subdivisions_SubdivisionId",
                table: "ApplicationForms");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationForms_SubdivisionActivityTypeId",
                table: "ApplicationForms");

            migrationBuilder.DropColumn(
                name: "SubdivisionActivityTypeId",
                table: "ApplicationForms");

            migrationBuilder.AlterColumn<int>(
                name: "SubdivisionId",
                table: "ApplicationForms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "subdivisionActivityTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Организатор мероприятия ");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationForms_Subdivisions_SubdivisionId",
                table: "ApplicationForms",
                column: "SubdivisionId",
                principalTable: "Subdivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
