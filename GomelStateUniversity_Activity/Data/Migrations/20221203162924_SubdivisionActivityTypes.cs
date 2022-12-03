using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class SubdivisionActivityTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subdivisionActivityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SubdivisionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subdivisionActivityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subdivisionActivityTypes_Subdivisions_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "subdivisionActivityTypes",
                columns: new[] { "Id", "Name", "SubdivisionId" },
                values: new object[,]
                {
                    { 1, "Организатор мероприятия ", 1 },
                    { 2, "Артист ", 1 },
                    { 3, "Спорт ", 2 },
                    { 4, "Вступление в организацию ", 4 },
                    { 5, "Работа в студенческом отряде ", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_subdivisionActivityTypes_SubdivisionId",
                table: "subdivisionActivityTypes",
                column: "SubdivisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subdivisionActivityTypes");
        }
    }
}
