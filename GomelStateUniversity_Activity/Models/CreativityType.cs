using System.ComponentModel.DataAnnotations;

namespace GomelStateUniversity_Activity.Models
{
    public class CreativityType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
