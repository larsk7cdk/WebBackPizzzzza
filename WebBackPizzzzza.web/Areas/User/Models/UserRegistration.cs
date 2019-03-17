using System.ComponentModel.DataAnnotations;

namespace WebBackPizzzzza.web.Areas.User.Models
{
    public class UserRegistration
    {
        public int UserRegistrationId { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Kodeord")]
        public string Password { get; set; }
    }
}