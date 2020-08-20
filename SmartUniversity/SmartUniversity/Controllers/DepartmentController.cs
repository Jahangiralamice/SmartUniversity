using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        // GET: Department
        public ActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
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
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(department);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = _context.Departments.SingleOrDefault(r => r.Id == id);
            return View(department);
        }
    }
}