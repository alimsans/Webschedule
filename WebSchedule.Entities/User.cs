using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
    }
}
