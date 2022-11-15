using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<EventUsers> EventUsers { get; set; }
        public ApplicationUser()
        {
            EventUsers = new List<EventUsers>();
        }
    }
}
