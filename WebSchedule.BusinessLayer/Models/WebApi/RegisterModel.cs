using System.ComponentModel.DataAnnotations;

namespace WebSchedule.BusinessLayer.Models.WebApi
{
    public class RegisterModel
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
