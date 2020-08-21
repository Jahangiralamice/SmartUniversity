using System.ComponentModel.DataAnnotations;

namespace SmartUniversity.Models
{
    public class Semester
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Semester name is required field")]
        [StringLength(10)]
        [Display(Name = "Semester Name")]
        public string SemesterName { get; set; }

    }
}