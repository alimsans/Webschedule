using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        public string Password { get; set; }

        [Required]
        public virtual RoleDto Role { get; set; }

        public virtual ICollection<ClassDto> Classes { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
    }
}
