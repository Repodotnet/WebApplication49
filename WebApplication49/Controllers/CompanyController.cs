using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication49.Models;

namespace WebApplication49.Controllers
{
    public class CompanyController : Controller
    {
        public neworgContext db;
      
        public CompanyController(neworgContext db1)
        {
            db = db1;
        }
        public IActionResult Index()
        {
            var t = db.Companies.Include(x=>x.Location);
            return View(t);
        }
      
        public IActionResult Create()
        {
            ViewBag.Locationid = new SelectList(db.Locations, "Locationid", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var Company = db.Companies.Find(id);
            ViewBag.Locationid = new SelectList(db.Locations, "Locationid", "Name");
            return View(Company);                    
        }

        [HttpPost]
        public IActionResult Edit(Company company,int id)
        {

           if (id != null)
            {
                db.Companies.Update(company);
                db.SaveChanges();
            
            }
            return RedirectToAction("Index"); 
        }
    }
}
