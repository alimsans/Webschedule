using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class ClassDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public virtual UserDto Teacher { get; set; }

        [Required]
        public virtual DisciplineDto Discipline { get; set; }

        [Required]
        public virtual GroupDto Group { get; set; }

        [Required]
        public virtual ClassroomDto Classroom { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
