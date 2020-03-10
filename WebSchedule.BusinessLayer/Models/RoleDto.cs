using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class RoleDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public RightsDto Rights { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
    }
}
