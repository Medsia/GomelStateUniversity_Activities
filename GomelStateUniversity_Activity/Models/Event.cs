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
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int TicketsCount { get; set; }
        public double TicketPrice { get; set; }

        public virtual Subdivision Subdivision { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public IEnumerable<EventUsers> EventUsers { get; set; }
        public Event()
        {
            
        }
        public Event(IFormCollection form, Subdivision subdivision)
        {
            Id = int.Parse(form["Id"]);
            Name = form["Name"];
            Description = form["Description"];
            DateTime = DateTime.Parse(form["DateTime"]);
            TicketsCount = int.Parse(form["TicketsCount"]);
            TicketPrice = double.Parse(form["TicketPrice"]);
            Subdivision = subdivision;
        }
        public void UpdateEvent(IFormCollection form, Subdivision subdivision)
        {
            Id = int.Parse(form["Id"]);
            Name = form["Name"];
            Description = form["Description"];
            DateTime = DateTime.Parse(form["DateTime"]);
            TicketsCount = int.Parse(form["TicketsCount"]);
            TicketPrice = double.Parse(form["TicketPrice"]);
            Subdivision = subdivision;
        }
    }
}
