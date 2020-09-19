using System.Linq;
using System.Web.Mvc;
using SmartUniversity.Models;
using SmartUniversity.ViewModels;

namespace SmartUniversity.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var teacherViewModel = new TeacherViewModel
            {
                Teacher = new Teacher(),
                Departments = _context.Departments.ToList(),
                Designations = _context.Designations.ToList()
            };
            return View(teacherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var teacherViewModel = new TeacherViewModel
            {
                Teacher = teacher,
                Departments = _context.Departments.ToList(),
                Designations = _context.Designations.ToList()
            };

            return View(teacherViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var teacher = _context.Teachers.Single(r => r.Id == id);
            if (teacher == null)
                return HttpNotFound();
            var teacherViewModel = new TeacherViewModel
            {
                Teacher = teacher,
                Departments = _context.Departments.ToList(),
                Designations = _context.Designations.ToList()
            };
            return View(teacherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher teacher)
        {
            var teacherViewModel = new TeacherViewModel
            {
                Teacher = teacher,
                Departments = _context.Departments.ToList(),
                Designations = _context.Designations.ToList()
            };
            if (ModelState.IsValid)
            {
                var teacherInDb = _context.Teachers.FirstOrDefault(r => r.Id == teacher.Id);
                teacherInDb.Name = teacher.Name;
                teacherInDb.Address = teacher.Address;
                teacherInDb.ContactNo = teacher.ContactNo;
                teacherInDb.CreditToBeTaken = teacher.CreditToBeTaken;
                teacherInDb.DepartmentId = teacher.DepartmentId;
                teacherInDb.DesignationId = teacher.DesignationId;
                teacherInDb.Email = teacher.Email;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherViewModel);
        }

        public ActionResult Details(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}