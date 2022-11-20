using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronym { get; set; }

        public string FullName { get => $"{Surname} {Name} {Patronym}"; }

        public string Faculty { get; set; }
        public int Year { get; set; }
        public string Group { get; set; }
        
        public IEnumerable<EventUser> EventUsers { get; set; }
    }
}
