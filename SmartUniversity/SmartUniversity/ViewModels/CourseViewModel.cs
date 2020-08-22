using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartUniversity.Models;

namespace SmartUniversity.ViewModels
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Semester> Semesters { get; set; }

    }
}