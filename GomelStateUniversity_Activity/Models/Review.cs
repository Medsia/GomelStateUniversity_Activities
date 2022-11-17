using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Event Event { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Review()
        {
        }

        public Review(IFormCollection form, DateTime dateTime, Event singleEvent, ApplicationUser applicationUser)
        {
            Text = form["Text"];
            DateTime = dateTime;
            Event = singleEvent;
            ApplicationUser = applicationUser;
        }
        public void UpdateReview(IFormCollection form, DateTime dateTime, Event singleEvent, ApplicationUser applicationUser)
        {
            Text = form["Text"];
            DateTime = dateTime;
            Event = singleEvent;
            ApplicationUser = applicationUser;
        }
    }
}
