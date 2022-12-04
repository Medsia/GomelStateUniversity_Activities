using GomelStateUniversity_Activity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class SubdivisionActivityType : ISubdivActivityType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int SubdivisionId { get; set; }

        public virtual Subdivision Subdivision { get; set; }

    }
}
