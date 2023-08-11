using System.ComponentModel.DataAnnotations;

namespace IETechInterview.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}
