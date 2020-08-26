using System.Linq;
using System.Web.Mvc;
using SmartUniversity.Models;
using SmartUniversity.ViewModels;

namespace SmartUniversity.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var departments = _context.Departments.ToList();
            var semesters = _context.Semesters.ToList();
            var courseViewModel = new CourseViewModel
            {
                Course = new Course(),
                Departments = departments,
                Semesters = semesters
            };
            return View(courseViewModel);
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            var courseViewModel = new CourseViewModel
            {
                Course = course,
                Departments = _context.Departments.ToList(),
                Semesters = _context.Semesters.ToList()
            };
            var isExist = _context.Courses.FirstOrDefault(r =>
                r.CourseCode == course.CourseCode || r.CourseName == course.CourseName);
            if (!ModelState.IsValid && isExist == null)
            {
                return View(courseViewModel);
            }

            var courseInDb = _context.Courses.SingleOrDefault(r => r.CourseCode == course.CourseCode || r.CourseName == course.CourseName);
            if (courseInDb == null && course.Credit >= 0.5 && course.Credit <= 5.0)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var course = _context.Courses.Single(r => r.Id == id);
            if (course == null)
                return HttpNotFound();
            var courseViewModel = new CourseViewModel
            {
                Course = course,
                Departments = _context.Departments.ToList(),
                Semesters = _context.Semesters.ToList()
            };
            return View(courseViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            var courseViewModel = new CourseViewModel
            {
                Course = course,
                Departments = _context.Departments.ToList(),
                Semesters = _context.Semesters.ToList()
            };
            var isExist = _context.Courses.FirstOrDefault(r =>
                r.CourseCode == course.CourseCode || r.CourseName == course.CourseName);
            if (ModelState.IsValid && course.Credit >= 0.5 && course.Credit <= 5.0 && isExist == null)
            {
                var courseInDb = _context.Courses.Single(r => r.Id == course.Id);
                courseInDb.CourseCode = course.CourseCode;
                courseInDb.CourseName = course.CourseName;
                courseInDb.Credit = course.Credit;
                courseInDb.Description = course.Description;
                courseInDb.DepartmentId = course.DepartmentId;
                courseInDb.SemesterId = course.SemesterId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseViewModel);
        }
    }
}