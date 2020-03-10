using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class LessonDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public WeekDayDto WeekDay { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
