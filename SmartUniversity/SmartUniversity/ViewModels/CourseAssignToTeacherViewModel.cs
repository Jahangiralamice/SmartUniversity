using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartUniversity.Models;

namespace SmartUniversity.ViewModels
{
    public class CourseAssignToTeacherViewModel
    {
        public CourseAssignToTeacher CourseAssignToTeacher { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        [Display(Name = "Credit To Be Taken")]
        public double CreditToBeTaken { get; set; }
        [Display(Name = "Remaining Credit")]
        public double RemainingCredit { get; set; }


    }
}