using System.ComponentModel.DataAnnotations;

namespace WebSchedule.Entities
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public WeekDay WeekDay { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
