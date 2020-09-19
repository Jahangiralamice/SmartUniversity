using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SmartUniversity.Models;
using SmartUniversity.ViewModels;

namespace SmartUniversity.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseAssignToTeacherController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var result = _context.CourseAssignToTeachers.ToList();

            return View(result);
        }

        public ActionResult Create()
        {
            var viewModel = new CourseAssignToTeacherViewModel
            {
                Departments = _context.Departments.ToList(),
                Teachers = _context.Teachers.ToList(),
                Courses = _context.Courses.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CourseAssignToTeacher objCourseAssignToTeacher)
        {
            return View();
        }

        public JsonResult GetAllTeacherByDepartmentId(int departmentId)
        {
            List<Teacher> teachers = new List<Teacher>();
            if (departmentId > 0)
            {
                teachers = _context.Teachers.Where(r => r.DepartmentId == departmentId).ToList();
            }
            else
            {
                teachers.Insert(0, new Teacher { Id = 0, Name = "Select Department first" });
            }

            var result = (from t in teachers
                          select new
                          {
                              id = t.Id,
                              name = t.Name
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCourseByDepartmentId(int departmentId)
        {
            List<Course> courses = new List<Course>();
            if (departmentId > 0)
            {
                courses = _context.Courses.Where(r => r.DepartmentId == departmentId).ToList();
            }
            else
            {
                courses.Insert(0, new Course { Id = 0, CourseCode = "Select Department first" });
            }

            var result = (from c in courses select new { id = c.Id, name = c.CourseCode }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherWithCourse(int teacherId)
        {
            var result = new Teacher();
            if (teacherId > 0)
            {
                result = _context.Teachers.SingleOrDefault(r => r.Id == teacherId);
            }
            TeacherWithCourseViewModel viewModel = new TeacherWithCourseViewModel
            {
                CreditToTake = result.CreditToBeTaken
            };
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}