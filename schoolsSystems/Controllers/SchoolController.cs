using schoolsSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models.DropMenu;

namespace schoolsSystems.Controllers
{
    public class SchoolController : Controller
    {
        EMEntities db;
        //
        // GET: /School/
        public SchoolController()
        {
            db = new EMEntities();
        }
        public ActionResult Index()
        {
            ViewBag.BodyTitle = "Школы";
            IEnumerable<City> cities = db.City;
            return View(cities);
        }
        public ActionResult City(int id)
        {
            IEnumerable<School> schools = db.School.Where(s=>s.CityId==id).ToList();
            ViewBag.City = db.City.Where(c => c.Id == id).FirstOrDefault().name;
            return View(schools);
        }
        public ActionResult Info(int id)
        {
            School school = db.School.FirstOrDefault(s => s.Id == id);
            ViewBag.SchoolId = id;
            ViewBag.Title = school.Name;
            ViewBag.BodyTitle = school.Name;
            return View(school);
        }
        public ActionResult Edit(School school)
        {
            if (ModelState.IsValid)
            {
                db.School.Add(school);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View("Edit",new School());
        }

        public ActionResult News(int schoolid = 0)
        {
            return View();
        }

        public ActionResult TimeTable()
        {
            return View();
        }

        public ActionResult Teachers()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Pupils()
        {
            return View();
        }

        public ActionResult Docs()
        {
            return View();
        }

        public PartialViewResult DropMenu(int SchoolId)
        {
            return PartialView(new DropMenu<School> { Id = SchoolId, list = db.School.ToList() });
        }
    }
}
