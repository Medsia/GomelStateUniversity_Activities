using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class SubdivisionRolesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "940f5024-7d9d-4750-a428-e4abd61b2ab9", "bada6509-76ee-41ae-82da-cf7a264b1cce", "mod", "MOD" },
                    { "d9cfc45b-3396-45b8-a906-90c36d665399", "37331a44-91f5-49ae-ba6b-c0493802ee4d", "culture", "CULTURE" },
                    { "d43a01de-f838-4de5-8324-4eabc4b2676d", "8068469c-7c3e-41c7-9de4-1098d8b16178", "sports", "SPORTS" },
                    { "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334", "d132befb-e09f-44aa-9ce7-12385584b790", "volunteer", "VOLUNTEER" },
                    { "bf073d17-9c3f-4101-9bd7-b8d44a301cd5", "f3237ebb-c8e8-453f-8cc7-513e50988e12", "psychologist", "PSYCHOLOGIST" },
                    { "32f105f4-f03d-428b-be62-c5523bf60f90", "b6be392d-87f2-465d-ac0e-2bcfce8ed5c4", "exhibition", "EXHIBITION" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32f105f4-f03d-428b-be62-c5523bf60f90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "940f5024-7d9d-4750-a428-e4abd61b2ab9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf073d17-9c3f-4101-9bd7-b8d44a301cd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d43a01de-f838-4de5-8324-4eabc4b2676d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9cfc45b-3396-45b8-a906-90c36d665399");
        }
    }
}
