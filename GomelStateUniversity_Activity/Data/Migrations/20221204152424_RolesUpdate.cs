using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class RolesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32f105f4-f03d-428b-be62-c5523bf60f90",
                column: "Name",
                value: "Мероприятия и выставки");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51781939-cf8c-4303-a65c-555397da7320",
                column: "Name",
                value: "Студент");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334",
                column: "Name",
                value: "Волонтерская деятельность");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "940f5024-7d9d-4750-a428-e4abd61b2ab9",
                column: "Name",
                value: "Модератор отзывов");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf073d17-9c3f-4101-9bd7-b8d44a301cd5",
                column: "Name",
                value: "Психолог");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d43a01de-f838-4de5-8324-4eabc4b2676d",
                column: "Name",
                value: "Спортивные мероприятия");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9cfc45b-3396-45b8-a906-90c36d665399",
                column: "Name",
                value: "Культурно-досуговая деятельность");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ffad0f4-9d7d-457f-b2b8-db87739d1648", "ba3d5fca-364b-412c-a4f4-966a63da1888", "Профсоюз", "UNION" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ffad0f4-9d7d-457f-b2b8-db87739d1648");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32f105f4-f03d-428b-be62-c5523bf60f90",
                column: "Name",
                value: "exhibition");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51781939-cf8c-4303-a65c-555397da7320",
                column: "Name",
                value: "student");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334",
                column: "Name",
                value: "volunteer");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "940f5024-7d9d-4750-a428-e4abd61b2ab9",
                column: "Name",
                value: "mod");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf073d17-9c3f-4101-9bd7-b8d44a301cd5",
                column: "Name",
                value: "psychologist");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d43a01de-f838-4de5-8324-4eabc4b2676d",
                column: "Name",
                value: "sports");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9cfc45b-3396-45b8-a906-90c36d665399",
                column: "Name",
                value: "culture");
        }
    }
}
