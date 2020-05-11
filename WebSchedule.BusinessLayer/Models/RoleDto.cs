using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSchedule.BusinessLayer.Models
{
    public class RoleDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public virtual ICollection<RightsDto> Rights { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
    }
}
