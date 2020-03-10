using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class ClassroomDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public virtual ICollection<ClassDto> Classes { get; set; }
    }
}
