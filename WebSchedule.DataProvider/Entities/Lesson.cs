using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSchedule.Infrastructure.Entities
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public WeekDay WeekDay { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public ICollection<Class> Classes { get; set; }
    }
}
