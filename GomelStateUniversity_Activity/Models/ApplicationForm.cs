using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class ApplicationForm
    {
        public Dictionary<string, string> ApplicationParameters { get; }
        public string RecipientContacts { get; }
        public virtual ApplicationUser ApplicationUser { get; }
        public virtual Subdivision Subdivision { get; }
    }
}
