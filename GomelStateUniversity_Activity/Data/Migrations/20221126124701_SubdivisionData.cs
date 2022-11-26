using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class SubdivisionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subdivisions",
                columns: new[] { "Id", "Contacts", "Name" },
                values: new object[,]
                {
                    { 1, "VELIKY@gsu.by", "Отдел культуры и досуга молодежи" },
                    { 2, "KULESHOV@gsu.by", "Спортивный клуб" },
                    { 3, "LVDUBROVSKAYA@gsu.by", "Информационно-аналитическая служба и отдел воспитательной работы с молодежью" },
                    { 4, "FEDORENKO@gsu.by", "Трудовая и волонтерская деятельность" },
                    { 5, "AZYAVCHIKOV@gsu.by", "Трудовая и волонтерская деятельность" },
                    { 6, "TROSHEVA@gsu.by", "Консультации психолога" },
                    { 7, "hodanovich@gsu.by", "Отзывы" },
                    { 8, "osnach@gsu.by", "Отзывы" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
