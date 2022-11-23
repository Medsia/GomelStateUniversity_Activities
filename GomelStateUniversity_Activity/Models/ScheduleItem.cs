using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class ScheduleItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public ScheduleItem()
        {
        }

        public ScheduleItem(DateTime dateTime, ApplicationUser applicationUser)
        {
            DateTime = dateTime;
            ApplicationUser = applicationUser;
        }

        public void UpdateScheduleItem(DateTime dateTime, ApplicationUser applicationUser)
        {
            DateTime = dateTime;
            ApplicationUser = applicationUser;
        }
    }
}
