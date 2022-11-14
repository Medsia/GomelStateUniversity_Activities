using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class Subdivision
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
