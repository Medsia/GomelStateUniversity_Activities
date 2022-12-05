using Microsoft.EntityFrameworkCore.Migrations;

namespace GomelStateUniversity_Activity.Data.Migrations
{
    public partial class SupervisorUsersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Faculty", "Group", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Patronym", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "Year" },
                values: new object[,]
                {
                    { "f04816a2-419b-4d29-b569-6d509f8d63fe", 0, "c02e82c7-cb2d-4a4e-bcd7-1889b763da32", "VELIKY@gsu.by", true, null, null, false, null, "Андрей", null, "VANIKOLAEVICH", "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==", "Николаевич", null, false, "25c0efa2-4ccb-4ae4-8bb0-047b97af9917", "Великий", false, "VANikolaevich", 0 },
                    { "968c7945-a469-4c92-be6c-61d88592a823", 0, "ef025c31-1271-46ea-ab3a-79f18aef3581", "KULESHOV@gsu.by", true, null, null, false, null, "Сергей", null, "KSNIKOLAEVICH", "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==", "Николаевич", null, false, "8b87ffaf-6110-423b-a779-529bd98f7064", "Кулешов", false, "KSNikolaevich", 0 },
                    { "35d5df8d-eb2d-4ec9-815f-76263f7aae95", 0, "29b3093f-ad45-41de-9df6-41dadbc67355", "osnach@gsu.by", true, null, null, false, null, "Татьяна", null, "OTMIHAILOVNA", "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==", "Михайловна", null, false, "9ad95f1d-34bb-4697-b780-1aeed68e64e2", "Оснач", false, "OTMihailovna", 0 },
                    { "ee24ba52-6293-4235-8e3b-559d57edd033", 0, "2de1bb74-ae12-4940-a760-7ad8ad93bfc7", "bardashevich@gsu.by", true, null, null, false, null, "Михаил", null, "BMNIKOLAEVICH", "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==", "Николаевич", null, false, "67fe43f2-9b8c-4380-8015-d74962a143bc", "Бардашевич", false, "BMNikolaevich", 0 },
                    { "1f78d986-070c-4685-b1f2-494d819c69e5", 0, "7f42e058-24e1-4caa-be1e-338f1ad0d307", "FEDORENKO@gsu.by", true, null, null, false, null, "Екатерина", null, "SENIKOLAEVNA", "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==", "Николаевна", null, false, "55422f21-c596-4215-b184-27bee54098fc", "Светогор", false, "SENikolaevna", 0 },
                    { "88ce42c0-5370-4e49-8276-a375e1154fb0", 0, "3046c0f0-0c2c-4b76-a11a-aa0c7335db45", "TROSHEVA@gsu.by", true, null, null, false, null, "Екатерина", null, "TENIKOLAEVNA", "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==", "Николаевна", null, false, "192f4ec8-d476-4adc-a77c-3a1bc40caea3", "Трошева", false, "TENikolaevna", 0 },
                    { "c5b07cf7-69bd-42f9-b0e0-7d048fb78501", 0, "b40c1a6c-dc21-4bb3-9171-17a371dd4173", "AZYAVCHIKOV@gsu.by", true, null, null, false, null, "Сергей", null, "ASOLEGOVICH", "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==", "Олегович", null, false, "ad0fc9b8-007d-4da5-af5c-bea44947fbc7", "Азявчиков", false, "ASOlegovich", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "f04816a2-419b-4d29-b569-6d509f8d63fe", "15d32ce6-852a-4591-afeb-af0293974d8a" },
                    { "f04816a2-419b-4d29-b569-6d509f8d63fe", "d9cfc45b-3396-45b8-a906-90c36d665399" },
                    { "968c7945-a469-4c92-be6c-61d88592a823", "15d32ce6-852a-4591-afeb-af0293974d8a" },
                    { "968c7945-a469-4c92-be6c-61d88592a823", "d43a01de-f838-4de5-8324-4eabc4b2676d" },
                    { "35d5df8d-eb2d-4ec9-815f-76263f7aae95", "15d32ce6-852a-4591-afeb-af0293974d8a" },
                    { "35d5df8d-eb2d-4ec9-815f-76263f7aae95", "32f105f4-f03d-428b-be62-c5523bf60f90" },
                    { "ee24ba52-6293-4235-8e3b-559d57edd033", "15d32ce6-852a-4591-afeb-af0293974d8a" },
                    { "ee24ba52-6293-4235-8e3b-559d57edd033", "32f105f4-f03d-428b-be62-c5523bf60f90" },
                    { "1f78d986-070c-4685-b1f2-494d819c69e5", "15d32ce6-852a-4591-afeb-af0293974d8a" },
                    { "1f78d986-070c-4685-b1f2-494d819c69e5", "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334" },
                    { "88ce42c0-5370-4e49-8276-a375e1154fb0", "15d32ce6-852a-4591-afeb-af0293974d8a" },
                    { "88ce42c0-5370-4e49-8276-a375e1154fb0", "940f5024-7d9d-4750-a428-e4abd61b2ab9" },
                    { "c5b07cf7-69bd-42f9-b0e0-7d048fb78501", "15d32ce6-852a-4591-afeb-af0293974d8a" },
                    { "c5b07cf7-69bd-42f9-b0e0-7d048fb78501", "0ffad0f4-9d7d-457f-b2b8-db87739d1648" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1f78d986-070c-4685-b1f2-494d819c69e5", "15d32ce6-852a-4591-afeb-af0293974d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1f78d986-070c-4685-b1f2-494d819c69e5", "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "35d5df8d-eb2d-4ec9-815f-76263f7aae95", "15d32ce6-852a-4591-afeb-af0293974d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "35d5df8d-eb2d-4ec9-815f-76263f7aae95", "32f105f4-f03d-428b-be62-c5523bf60f90" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "88ce42c0-5370-4e49-8276-a375e1154fb0", "15d32ce6-852a-4591-afeb-af0293974d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "88ce42c0-5370-4e49-8276-a375e1154fb0", "940f5024-7d9d-4750-a428-e4abd61b2ab9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "968c7945-a469-4c92-be6c-61d88592a823", "15d32ce6-852a-4591-afeb-af0293974d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "968c7945-a469-4c92-be6c-61d88592a823", "d43a01de-f838-4de5-8324-4eabc4b2676d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c5b07cf7-69bd-42f9-b0e0-7d048fb78501", "0ffad0f4-9d7d-457f-b2b8-db87739d1648" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c5b07cf7-69bd-42f9-b0e0-7d048fb78501", "15d32ce6-852a-4591-afeb-af0293974d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ee24ba52-6293-4235-8e3b-559d57edd033", "15d32ce6-852a-4591-afeb-af0293974d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ee24ba52-6293-4235-8e3b-559d57edd033", "32f105f4-f03d-428b-be62-c5523bf60f90" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f04816a2-419b-4d29-b569-6d509f8d63fe", "15d32ce6-852a-4591-afeb-af0293974d8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f04816a2-419b-4d29-b569-6d509f8d63fe", "d9cfc45b-3396-45b8-a906-90c36d665399" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f78d986-070c-4685-b1f2-494d819c69e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35d5df8d-eb2d-4ec9-815f-76263f7aae95");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88ce42c0-5370-4e49-8276-a375e1154fb0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "968c7945-a469-4c92-be6c-61d88592a823");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5b07cf7-69bd-42f9-b0e0-7d048fb78501");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee24ba52-6293-4235-8e3b-559d57edd033");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f04816a2-419b-4d29-b569-6d509f8d63fe");
        }
    }
}
