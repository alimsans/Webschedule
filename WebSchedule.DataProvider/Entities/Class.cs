using System.ComponentModel.DataAnnotations;

namespace WebSchedule.Infrastructure.Entities
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public virtual User Teacher { get; set; }

        [Required]
        public virtual Discipline Discipline { get; set; }

        [Required]
        public virtual Group Group { get; set; }

        [Required]
        public virtual Classroom Classroom { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
