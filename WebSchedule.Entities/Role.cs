using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public Rights Rights { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
