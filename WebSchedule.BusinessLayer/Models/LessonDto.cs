using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models
{
    public class LessonDto
    {
        public int Id { get; set; }

        public WeekDayDto WeekDay { get; set; }

        public int Order { get; set; }
    }
}
