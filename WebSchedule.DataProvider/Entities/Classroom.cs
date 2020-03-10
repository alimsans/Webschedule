using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.Infrastructure.Entities
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
