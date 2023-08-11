using System.ComponentModel.DataAnnotations;

namespace IETechInterview.Models
{
    public class Employees
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Staff Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "Division")]
        public string Division { get; set; }
        public bool Active { get; set; }
    }
}
