using GomelStateUniversity_Activity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GomelStateUniversity_Activity.Models
{
    public class CreativityType : ISubdivActivityType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
