using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RightsDto Rights { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }
    }
}
