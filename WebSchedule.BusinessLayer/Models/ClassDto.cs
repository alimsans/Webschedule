using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class ClassDto
    { 
        public int Id { get; set; }
        
        public virtual UserDto Teacher { get; set; }

        public virtual DisciplineDto Discipline { get; set; }

        public virtual GroupDto Group { get; set; }

        public virtual ClassroomDto Classroom { get; set; }

        public int Order { get; set; }
    }
}
