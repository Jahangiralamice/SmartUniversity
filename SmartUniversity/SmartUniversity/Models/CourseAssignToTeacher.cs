using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartUniversity.Models
{
    public class CourseAssignToTeacher
    {
        public int Id { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}