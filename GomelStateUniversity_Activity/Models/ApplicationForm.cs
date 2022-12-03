using GomelStateUniversity_Activity.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class ApplicationForm
    {
        [Key]
        public int Id { get; set; }
        public string RecipientContacts { get; set; }

        [NotMapped]
        public ISubdivActivityType SubdivActivityType { get; set; }
        public Dictionary<string, string> ApplicationParameters { get; set; } = new Dictionary<string, string>();
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Subdivision Subdivision { get; set; }

        public ApplicationForm()
        {

        }
        public ApplicationForm(IFormCollection form, ISubdivActivityType subdivActivityType)
        {
            if(subdivActivityType is SportType)
                ApplicationParameters.Add("Спорт: ", form["ActivityType"]);
            else if (subdivActivityType is CreativityType)
                ApplicationParameters.Add("Деятельность: ", form["ActivityType"]);
            else if (subdivActivityType is SubdivisionActivityType)
                ApplicationParameters.Add("Деятельность: ", subdivActivityType.Name);
            else if (subdivActivityType is LaborDirection)
                ApplicationParameters.Add("Трудовое направление: ", form["ActivityType"]);
            else if (subdivActivityType is Data.Data.Organization)
                ApplicationParameters.Add("Организация : ", form["ActivityType"]);
            SubdivActivityType = subdivActivityType;
        }
    }
}
