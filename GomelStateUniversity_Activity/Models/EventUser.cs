using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class EventUser
    {
        public string ApplicationUserId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public EventUser(int eventId, string userId)
        {
            EventId = eventId;
            ApplicationUserId = userId;           
        }
        public EventUser()
        {

        }
    }
}
