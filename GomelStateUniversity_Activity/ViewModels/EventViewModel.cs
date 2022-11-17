using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.ViewModels
{
    public class EventViewModel
    {
        public Event Event {get;set;}
        public IList<SelectListItem> Subdivision = new List<SelectListItem>();
        public string SubdivisionName { get; set; }
        public EventViewModel(Event @event, IList<Subdivision> subdivisions)
        {
            Event = @event;
            SubdivisionName = Event.Subdivision.Name;
            foreach (var subdivision in subdivisions)
            {
                Subdivision.Add(new SelectListItem() { Text = subdivision.Name });
            }
        }
        public EventViewModel(IList<Subdivision> subdivisions)
        {
            foreach (var subdivision in subdivisions)
            {
                Subdivision.Add(new SelectListItem() { Text = subdivision.Name });
            }
        }
        public EventViewModel()
        {

        }
    }
}
