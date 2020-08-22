using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace SmartUniversity.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course Code")]
        [Required(ErrorMessage = "Course code is requied field")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Course code should be 5 to 10 characters long")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course name is required field")]
        [StringLength(255)]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        public double Credit { get; set; }

        public string Description { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
    }
}