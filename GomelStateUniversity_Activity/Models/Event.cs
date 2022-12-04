using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PosterPath { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int TicketsCount { get; set; }
        public double TicketPrice { get; set; }

        public virtual Subdivision Subdivision { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public IEnumerable<EventUser> EventUsers { get; set; }
        public Event()
        {
            
        }
        public Event(IFormCollection form, Subdivision subdivision, string imgPath)
        {
            Name = form["Event.Name"].ToString();
            PosterPath = imgPath;
            Description = form["Event.Description"].ToString();
            DateTime = DateTime.Parse(form["Event.DateTime"].ToString());
            TicketsCount = int.Parse(form["Event.TicketsCount"].ToString());
            TicketPrice = double.Parse(form["Event.TicketPrice"].ToString());
            Subdivision = subdivision;
        }
        public void UpdateEvent(IFormCollection form, Subdivision subdivision, string imgPath)
        {
            Name = form["Event.Name"].ToString();
            PosterPath = imgPath;
            Description = form["Event.Description"].ToString();
            DateTime = DateTime.Parse(form["Event.DateTime"].ToString());
            TicketsCount = int.Parse(form["Event.TicketsCount"].ToString());
            TicketPrice = double.Parse(form["Event.TicketPrice"].ToString());
            Subdivision = subdivision;
        }
    }
}
