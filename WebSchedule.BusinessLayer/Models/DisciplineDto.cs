using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class DisciplineDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string Name { get; set; }

        public virtual ICollection<ClassDto> Classes { get; set; }
    }
}
