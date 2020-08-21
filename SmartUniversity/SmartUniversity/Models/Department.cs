using System.ComponentModel.DataAnnotations;

namespace SmartUniversity.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code should be 2 to 7 characters long")]
        public string Code { get; set; }

        [StringLength(255)]
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department Name is required field")]
        public string Name { get; set; }

    }
}