using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.Infrastructure.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        [MaxLength(64)]
        public string Jwt { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

        public virtual Group Group { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
    }
}
