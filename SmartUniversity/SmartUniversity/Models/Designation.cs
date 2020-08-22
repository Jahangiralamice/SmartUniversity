using System.ComponentModel.DataAnnotations;

namespace SmartUniversity.Models
{
    public class Designation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Designation name is required field")]
        [StringLength(50)]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
    }
}