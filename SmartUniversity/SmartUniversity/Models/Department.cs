using System.ComponentModel.DataAnnotations;

namespace SmartUniversity.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code should be 2 to 7 characters long")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }

    }
}