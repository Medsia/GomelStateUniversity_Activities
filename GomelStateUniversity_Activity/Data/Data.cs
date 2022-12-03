using GomelStateUniversity_Activity.Models;
using GomelStateUniversity_Activity.Interfaces;
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
