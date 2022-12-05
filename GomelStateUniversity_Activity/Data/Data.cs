using GomelStateUniversity_Activity.Models;
using GomelStateUniversity_Activity.Interfaces;
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

        public static readonly List<CreativityType> CreativityTypesDtoList = new List<CreativityType>
        {
             new CreativityType{
                Id = 1,
                Name = "Песня" },

             new CreativityType{
                Id = 2,
                Name = "Танец" },

             new CreativityType{
                Id = 3,
                Name = "Другое" },
        };

        public static readonly List<SportType> SportTypesDtoList = new List<SportType>
        {
             new SportType{
                Id = 1,
                Name = "Карате" },

             new SportType{
                Id = 2,
                Name = "Бадминтон" },

             new SportType{
                Id = 3,
                Name = "Гиревой спорт" },

             new SportType{
                Id = 4,
                Name = "Волейбол" },
        };

        public static readonly List<LaborDirection> LaborDirectionsDtoList = new List<LaborDirection>
        {
             new LaborDirection{
                Id = 1,
                Name = "Педагогический отряд" },

             new LaborDirection{
                Id = 2,
                Name = "Сельскохозяйственные работы" },

              new LaborDirection{
                Id = 3,
                Name = "Лесник" },
        };

        public static readonly List<SubdivisionActivityType> SubdivisionActivityTypesDtoList = new List<SubdivisionActivityType>
        {
             new SubdivisionActivityType{
                Id = 1,
                Name = "Организатор ",
                SubdivisionId = 1},             

             new SubdivisionActivityType{
                Id = 2,
                Name = "Артист ",
                SubdivisionId = 1 },

              new SubdivisionActivityType{
                Id = 3,
                Name = "Спорт ",
                SubdivisionId = 2 },

              new SubdivisionActivityType{
                Id = 4,
                Name = "Вступление в организацию ",
                SubdivisionId = 4 },

              new SubdivisionActivityType{
                Id = 5,
                Name = "Работа в студенческом отряде ",
                SubdivisionId = 4 },
        };

        public static readonly List<IdentityRole> RoleDtoList = new List<IdentityRole>
        {
            new IdentityRole{   // Администратор
                Id = "6aedd11d-510d-4017-b685-1c6b6fa92b91",
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "bce813f4-7061-4267-b682-8efc78c965fc" },

            new IdentityRole{   // Руководитель
                Id = "15d32ce6-852a-4591-afeb-af0293974d8a",
                Name = "supervisor",
                NormalizedName = "SUPERVISOR",
                ConcurrencyStamp = "5a8cecba-d1e6-4129-8381-92ceb11af503" },

            new IdentityRole{   // Студент
                Id = "51781939-cf8c-4303-a65c-555397da7320",
                Name = "Студент",
                NormalizedName = "STUDENT",
                ConcurrencyStamp = "c743a1fb-70f1-4901-860c-2fe87dc7ca4a" },



            new IdentityRole{   // Отзывы
                Id = "940f5024-7d9d-4750-a428-e4abd61b2ab9",
                Name = "Модератор отзывов",
                NormalizedName = "MOD",
                ConcurrencyStamp = "bada6509-76ee-41ae-82da-cf7a264b1cce" },

            new IdentityRole{   // Культурно-досуговая деятельность
                Id = "d9cfc45b-3396-45b8-a906-90c36d665399",
                Name = "Культурно-досуговая деятельность",
                NormalizedName = "CULTURE",
                ConcurrencyStamp = "37331a44-91f5-49ae-ba6b-c0493802ee4d" },

            new IdentityRole{   // Спортивные мероприятия
                Id = "d43a01de-f838-4de5-8324-4eabc4b2676d",
                Name = "Спортивные мероприятия",
                NormalizedName = "SPORTS",
                ConcurrencyStamp = "8068469c-7c3e-41c7-9de4-1098d8b16178" },

            new IdentityRole{   // Волонтерская деятельность
                Id = "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334",
                Name = "Волонтерская деятельность",
                NormalizedName = "VOLUNTEER",
                ConcurrencyStamp = "d132befb-e09f-44aa-9ce7-12385584b790" },

            new IdentityRole{   // Профсоюз
                Id = "0ffad0f4-9d7d-457f-b2b8-db87739d1648",
                Name = "Профсоюз",
                NormalizedName = "UNION",
                ConcurrencyStamp = "ba3d5fca-364b-412c-a4f4-966a63da1888" },

            new IdentityRole{   // Психолог
                Id = "bf073d17-9c3f-4101-9bd7-b8d44a301cd5",
                Name = "Психолог",
                NormalizedName = "PSYCHOLOGIST",
                ConcurrencyStamp = "f3237ebb-c8e8-453f-8cc7-513e50988e12" },

            new IdentityRole{   // Мероприятия и выставки
                Id = "32f105f4-f03d-428b-be62-c5523bf60f90",
                Name = "Мероприятия и выставки",
                NormalizedName = "EXHIBITION",
                ConcurrencyStamp = "b6be392d-87f2-465d-ac0e-2bcfce8ed5c4" }
        };



        public static readonly List<ApplicationUser> UserDtoList = new List<ApplicationUser>
        {
            new ApplicationUser{
                Id = "e9c84823-8e52-4bce-aeab-5c3435059c5c",
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                ConcurrencyStamp = "23d875e1-2d80-4905-a52d-8584ecb37f37",
                SecurityStamp = "d434d335-e0c7-4433-b3b7-3dfba101a15f",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" }, // QWErty123!



            new ApplicationUser{
                Id = "f04816a2-419b-4d29-b569-6d509f8d63fe",
                UserName = "VANikolaevich",
                Surname = "Великий",
                Name = "Андрей",
                Patronym = "Николаевич",
                Email = "VELIKY@gsu.by",
                EmailConfirmed = true,
                NormalizedUserName = "VANIKOLAEVICH",
                ConcurrencyStamp = "c02e82c7-cb2d-4a4e-bcd7-1889b763da32",
                SecurityStamp = "25c0efa2-4ccb-4ae4-8bb0-047b97af9917",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" }, // QWErty123!


            new ApplicationUser{
                Id = "968c7945-a469-4c92-be6c-61d88592a823",
                UserName = "KSNikolaevich",
                Surname = "Кулешов",
                Name = "Сергей",
                Patronym = "Николаевич",
                Email = "KULESHOV@gsu.by",
                EmailConfirmed = true,
                NormalizedUserName = "KSNIKOLAEVICH",
                ConcurrencyStamp = "ef025c31-1271-46ea-ab3a-79f18aef3581",
                SecurityStamp = "8b87ffaf-6110-423b-a779-529bd98f7064",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" }, // QWErty123!

            new ApplicationUser{
                Id = "35d5df8d-eb2d-4ec9-815f-76263f7aae95",
                UserName = "OTMihailovna",
                Surname = "Оснач",
                Name = "Татьяна",
                Patronym = "Михайловна",
                Email = "osnach@gsu.by",
                EmailConfirmed = true,
                NormalizedUserName = "OTMIHAILOVNA",
                ConcurrencyStamp = "29b3093f-ad45-41de-9df6-41dadbc67355",
                SecurityStamp = "9ad95f1d-34bb-4697-b780-1aeed68e64e2",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" }, // QWErty123!

            new ApplicationUser{
                Id = "ee24ba52-6293-4235-8e3b-559d57edd033",
                UserName = "BMNikolaevich",
                Surname = "Бардашевич",
                Name = "Михаил",
                Patronym = "Николаевич",
                Email = "bardashevich@gsu.by",
                EmailConfirmed = true,
                NormalizedUserName = "BMNIKOLAEVICH",
                ConcurrencyStamp = "2de1bb74-ae12-4940-a760-7ad8ad93bfc7",
                SecurityStamp = "67fe43f2-9b8c-4380-8015-d74962a143bc",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" }, // QWErty123!

            new ApplicationUser{
                Id = "1f78d986-070c-4685-b1f2-494d819c69e5",
                UserName = "SENikolaevna",
                Surname = "Светогор",
                Name = "Екатерина",
                Patronym = "Николаевна",
                Email = "FEDORENKO@gsu.by",
                EmailConfirmed = true,
                NormalizedUserName = "SENIKOLAEVNA",
                ConcurrencyStamp = "7f42e058-24e1-4caa-be1e-338f1ad0d307",
                SecurityStamp = "55422f21-c596-4215-b184-27bee54098fc",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" }, // QWErty123!

            new ApplicationUser{
                Id = "88ce42c0-5370-4e49-8276-a375e1154fb0",
                UserName = "TENikolaevna",
                Surname = "Трошева",
                Name = "Екатерина",
                Patronym = "Николаевна",
                Email = "TROSHEVA@gsu.by",
                EmailConfirmed = true,
                NormalizedUserName = "TENIKOLAEVNA",
                ConcurrencyStamp = "3046c0f0-0c2c-4b76-a11a-aa0c7335db45",
                SecurityStamp = "192f4ec8-d476-4adc-a77c-3a1bc40caea3",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" }, // QWErty123!

            new ApplicationUser{
                Id = "c5b07cf7-69bd-42f9-b0e0-7d048fb78501",
                UserName = "ASOlegovich",
                Surname = "Азявчиков",
                Name = "Сергей",
                Patronym = "Олегович",
                Email = "AZYAVCHIKOV@gsu.by",
                EmailConfirmed = true,
                NormalizedUserName = "ASOLEGOVICH",
                ConcurrencyStamp = "b40c1a6c-dc21-4bb3-9171-17a371dd4173",
                SecurityStamp = "ad0fc9b8-007d-4da5-af5c-bea44947fbc7",
                PasswordHash = "AQAAAAEAACcQAAAAEC9RVRfJpeULnDo9YKJBBIQpty/59BsyI14YA74+l5fcDOA/qCtcZUNBMpRDN/cokQ==" }, // QWErty123!

        };



        public static readonly List<IdentityUserRole<string>> UserRoleDtoList = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>    // Administrator - admin
                {
                    UserId = "e9c84823-8e52-4bce-aeab-5c3435059c5c",
                    RoleId = "6aedd11d-510d-4017-b685-1c6b6fa92b91"
                },


            new IdentityUserRole<string>    // VANikolaevich - supervisor
                {
                    UserId = "f04816a2-419b-4d29-b569-6d509f8d63fe",
                    RoleId = "15d32ce6-852a-4591-afeb-af0293974d8a"
                },
            new IdentityUserRole<string>    // VANikolaevich - CULTURE
                {
                    UserId = "f04816a2-419b-4d29-b569-6d509f8d63fe",
                    RoleId = "d9cfc45b-3396-45b8-a906-90c36d665399"
                },



            new IdentityUserRole<string>    // KSNikolaevich - supervisor
                {
                    UserId = "968c7945-a469-4c92-be6c-61d88592a823",
                    RoleId = "15d32ce6-852a-4591-afeb-af0293974d8a"
                },
            new IdentityUserRole<string>    // KSNikolaevich - SPORTS
                {
                    UserId = "968c7945-a469-4c92-be6c-61d88592a823",
                    RoleId = "d43a01de-f838-4de5-8324-4eabc4b2676d"
                },


            new IdentityUserRole<string>    // OTMihailovna - supervisor
                {
                    UserId = "35d5df8d-eb2d-4ec9-815f-76263f7aae95",
                    RoleId = "15d32ce6-852a-4591-afeb-af0293974d8a"
                },
            new IdentityUserRole<string>    // OTMihailovna - EXHIBITION
                {
                    UserId = "35d5df8d-eb2d-4ec9-815f-76263f7aae95",
                    RoleId = "32f105f4-f03d-428b-be62-c5523bf60f90"
                },


            new IdentityUserRole<string>    // BMNikolaevich - supervisor
                {
                    UserId = "ee24ba52-6293-4235-8e3b-559d57edd033",
                    RoleId = "15d32ce6-852a-4591-afeb-af0293974d8a"
                },
            new IdentityUserRole<string>    // BMNikolaevich - EXHIBITION
                {
                    UserId = "ee24ba52-6293-4235-8e3b-559d57edd033",
                    RoleId = "32f105f4-f03d-428b-be62-c5523bf60f90"
                },


            new IdentityUserRole<string>    // SENikolaevna - supervisor
                {
                    UserId = "1f78d986-070c-4685-b1f2-494d819c69e5",
                    RoleId = "15d32ce6-852a-4591-afeb-af0293974d8a"
                },
            new IdentityUserRole<string>    // SENikolaevna - VOLUNTEER
                {
                    UserId = "1f78d986-070c-4685-b1f2-494d819c69e5",
                    RoleId = "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334"
                },


            new IdentityUserRole<string>    // TENikolaevna - supervisor
                {
                    UserId = "88ce42c0-5370-4e49-8276-a375e1154fb0",
                    RoleId = "15d32ce6-852a-4591-afeb-af0293974d8a"
                },
            new IdentityUserRole<string>    // TENikolaevna - MOD
                {
                    UserId = "88ce42c0-5370-4e49-8276-a375e1154fb0",
                    RoleId = "940f5024-7d9d-4750-a428-e4abd61b2ab9"
                },


            new IdentityUserRole<string>    // ASOlegovich - supervisor
                {
                    UserId = "c5b07cf7-69bd-42f9-b0e0-7d048fb78501",
                    RoleId = "15d32ce6-852a-4591-afeb-af0293974d8a"
                },
            new IdentityUserRole<string>    // ASOlegovich - UNION
                {
                    UserId = "c5b07cf7-69bd-42f9-b0e0-7d048fb78501",
                    RoleId = "0ffad0f4-9d7d-457f-b2b8-db87739d1648"
                },
        };

        public class Organization : ISubdivActivityType
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public static readonly List<Organization> organizationsData = new List<Organization>
            {
                new Organization{
                    Id = 1,
                    Name = "БРСМ" },

                new Organization{
                    Id = 2,
                    Name = "Студенческий совет" },

                new Organization{
                    Id = 3,
                    Name = "Профсоюз" },

                new Organization{
                    Id = 4,
                    Name = "Волонтерская деятельность" },
            };
        }
    }
}
