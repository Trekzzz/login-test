using System.ComponentModel.DataAnnotations;

namespace LoginModule.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
