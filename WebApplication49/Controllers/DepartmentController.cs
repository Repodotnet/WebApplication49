using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication49.Models;

namespace WebApplication49.Controllers
{
    public class DepartmentController : Controller
    {
        public neworgContext db;
        public DepartmentController(neworgContext db1)
        {
            db = db1;
        }

        public IActionResult Index()
        {
            return View(db.Departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.organisation = db.Companies.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return View();
        }

    }
}
