using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public static class Data
    {
        public static readonly List<Subdivision> SubdivisionDtoList = new List<Subdivision>
        {
             new Subdivision{
                Id = 1,
                Name = "Отдел культуры и досуга молодежи",
                Contacts = "VELIKY@gsu.by" },

            new Subdivision{
                Id = 2,
                Name = "Спортивный клуб",
                Contacts = "KULESHOV@gsu.by" },

            new Subdivision{
                Id = 3,
                Name = "Информационно-аналитическая служба и отдел воспитательной работы с молодежью",
                Contacts = "LVDUBROVSKAYA@gsu.by" },

            new Subdivision{
                Id = 4,
                Name = "Трудовая и волонтерская деятельность",
                Contacts = "FEDORENKO@gsu.by" },

            new Subdivision{
                Id = 5,
                Name = "Трудовая и волонтерская деятельность",
                Contacts = "AZYAVCHIKOV@gsu.by" },

            new Subdivision{
                Id = 6,
                Name = "Консультации психолога",
                Contacts = "TROSHEVA@gsu.by" },

            new Subdivision{
                Id = 7,
                Name = "Отзывы",
                Contacts = "hodanovich@gsu.by" },

            new Subdivision{
                Id = 8,
                Name = "Отзывы",
                Contacts = "osnach@gsu.by" },

        };

        public static readonly List<IdentityRole> RoleDtoList = new List<IdentityRole>
        {
            new IdentityRole{
                Id = "6aedd11d-510d-4017-b685-1c6b6fa92b91",
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "bce813f4-7061-4267-b682-8efc78c965fc" },

            new IdentityRole{
                Id = "15d32ce6-852a-4591-afeb-af0293974d8a",
                Name = "supervisor",
                NormalizedName = "SUPERVISOR",
                ConcurrencyStamp = "5a8cecba-d1e6-4129-8381-92ceb11af503" },

            new IdentityRole{
                Id = "51781939-cf8c-4303-a65c-555397da7320",
                Name = "student",
                NormalizedName = "STUDENT",
                ConcurrencyStamp = "c743a1fb-70f1-4901-860c-2fe87dc7ca4a" }
        };

        public static readonly List<ApplicationUser> UserDtoList = new List<ApplicationUser>
        {
            new ApplicationUser{
                Id = "e9c84823-8e52-4bce-aeab-5c3435059c5c",
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                ConcurrencyStamp = "23d875e1-2d80-4905-a52d-8584ecb37f37",
                SecurityStamp = "d434d335-e0c7-4433-b3b7-3dfba101a15f",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" } // QWErty123!
        };

        public static readonly List<IdentityUserRole<string>> UserRoleDtoList = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
                {
                    UserId = "e9c84823-8e52-4bce-aeab-5c3435059c5c",
                    RoleId = "6aedd11d-510d-4017-b685-1c6b6fa92b91"
                }
        };
    }
}
