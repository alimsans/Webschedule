using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.Entities
{
    public class Discipline
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string Name { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
