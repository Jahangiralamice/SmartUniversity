using System.Linq;
using System.Web.Mvc;
using SmartUniversity.Models;

namespace SmartUniversity.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        public ActionResult Details(int id)
        {
            var department = _context.Departments.SingleOrDefault(r => r.Id == id);
            if (department == null)
                return HttpNotFound();
            return View(department);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            var isExist =
                _context.Departments.FirstOrDefault(r => r.Name == department.Name || r.Code == department.Code);
            if (ModelState.IsValid && isExist == null)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                TempData["Success"] = department.Name + " " + "department successfully saved.";
                return RedirectToAction("Index");

            }
            if (isExist != null)
            {
                ViewBag.ExistMessage = "Department Name or Code already exist!!";
            }
            return View(department);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = _context.Departments.SingleOrDefault(r => r.Id == id);
            if (department == null)
                return HttpNotFound();
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            var isExist = _context.Departments.FirstOrDefault(r => r.Id != department.Id || r.Name == department.Name);
            if (ModelState.IsValid && isExist == null)
            {
                var departmentInDb = _context.Departments.Single(r => r.Id == department.Id);
                departmentInDb.Code = department.Code;
                departmentInDb.Name = department.Name;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            if (isExist != null)
            {
                ViewBag.ExistMessage = "Department Name or Code already exist!!";
            }

            return View(department);
        }
    }
}