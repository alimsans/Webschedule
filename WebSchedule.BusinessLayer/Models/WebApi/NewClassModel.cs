using System;
using System.Collections.Generic;
using System.Text;

namespace WebSchedule.BusinessLayer.Models.WebApi
{
    public class NewClassModel
    {
        public int TeacherId { get; set; }
        public int ClassroomId { get; set; }
        public int DisciplineId { get; set; }
        public int GroupId { get; set; }
        public int LessonId { get; set; }
    }
}
