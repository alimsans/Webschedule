using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class DisciplineDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ClassDto> Classes { get; set; }
    }
}
