using System.Collections.Generic;
using SmartUniversity.Models;

namespace SmartUniversity.ViewModels
{
    public class TeacherViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Designation> Designations { get; set; }

    }
}