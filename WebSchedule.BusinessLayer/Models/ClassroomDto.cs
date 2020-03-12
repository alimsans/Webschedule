using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class ClassroomDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public virtual ICollection<ClassDto> Classes { get; set; }
    }
}
