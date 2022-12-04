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
            new IdentityRole{   // Администратор - добавляет и редактирует мероприятия
                Id = "6aedd11d-510d-4017-b685-1c6b6fa92b91",
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "bce813f4-7061-4267-b682-8efc78c965fc" },

            new IdentityRole{   // Руководитель - получает уведомления о записавшихся и отписавшихся
                Id = "15d32ce6-852a-4591-afeb-af0293974d8a",
                Name = "supervisor",
                NormalizedName = "SUPERVISOR",
                ConcurrencyStamp = "5a8cecba-d1e6-4129-8381-92ceb11af503" },

            new IdentityRole{   // Студент - просто челы
                Id = "51781939-cf8c-4303-a65c-555397da7320",
                Name = "student",
                NormalizedName = "STUDENT",
                ConcurrencyStamp = "c743a1fb-70f1-4901-860c-2fe87dc7ca4a" },



            new IdentityRole{   // Отзывы
                Id = "940f5024-7d9d-4750-a428-e4abd61b2ab9",
                Name = "mod",
                NormalizedName = "MOD",
                ConcurrencyStamp = "bada6509-76ee-41ae-82da-cf7a264b1cce" },

            new IdentityRole{   // Культурно-досуговая деятельность
                Id = "d9cfc45b-3396-45b8-a906-90c36d665399",
                Name = "culture",
                NormalizedName = "CULTURE",
                ConcurrencyStamp = "37331a44-91f5-49ae-ba6b-c0493802ee4d" },

            new IdentityRole{   // Спортивные мероприятия
                Id = "d43a01de-f838-4de5-8324-4eabc4b2676d",
                Name = "sports",
                NormalizedName = "SPORTS",
                ConcurrencyStamp = "8068469c-7c3e-41c7-9de4-1098d8b16178" },

            new IdentityRole{   // Волонтерская деятельность
                Id = "5f3d63f0-61d5-4dd3-bf54-3b0a5c88c334",
                Name = "volunteer",
                NormalizedName = "VOLUNTEER",
                ConcurrencyStamp = "d132befb-e09f-44aa-9ce7-12385584b790" },

            new IdentityRole{   // Психолог
                Id = "bf073d17-9c3f-4101-9bd7-b8d44a301cd5",
                Name = "psychologist",
                NormalizedName = "PSYCHOLOGIST",
                ConcurrencyStamp = "f3237ebb-c8e8-453f-8cc7-513e50988e12" },

            new IdentityRole{   // Мероприятия и выставки
                Id = "32f105f4-f03d-428b-be62-c5523bf60f90",
                Name = "exhibition",
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
