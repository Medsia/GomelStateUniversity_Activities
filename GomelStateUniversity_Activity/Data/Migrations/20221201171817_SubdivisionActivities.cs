using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class SubdivisionActivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreativityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreativityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborDirections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborDirections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CreativityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Песня" },
                    { 2, "Танец" },
                    { 3, "Другое" }
                });

            migrationBuilder.InsertData(
                table: "LaborDirections",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Педагогический отряд" },
                    { 2, "Сельскохозяйственные работы" },
                    { 3, "Лесник" }
                });

            migrationBuilder.InsertData(
                table: "SportTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Карате" },
                    { 2, "Бадминтон" },
                    { 3, "Гиревой спорт" },
                    { 4, "Волейбол" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreativityTypes");

            migrationBuilder.DropTable(
                name: "LaborDirections");

            migrationBuilder.DropTable(
                name: "SportTypes");
        }
    }
}
