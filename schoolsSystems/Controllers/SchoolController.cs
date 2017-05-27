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
            ViewBag.BodyTitle = "Список школ города " + ViewBag.City;
            return View(schools);
        }
        public ActionResult Info(int id)
        {
            School school = db.School.FirstOrDefault(s => s.Id == id);
            ViewData.Add("school", school);
            ViewBag.Title = school.Name;
            ViewBag.BodyTitle = school.Name;
            return View(school);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(School school)
        {
            ViewBag.BodyTitle = "Добавить школу";
            if (ModelState.IsValid)
            {
                db.School.Add(school);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.BodyTitle = "Добавить школу";
            return View("Edit",new School());
        }

        public ActionResult News(int schoolid = 0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolid);
            ViewData.Add("school", school);
            ViewBag.BodyTitle = "Новости";
            return RedirectToAction("Index", "News", new { SchoolId = schoolid });
        }

        public ActionResult TimeTable(int schoolId=0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            ViewBag.BodyTitle = "Расписание";
            return View(db.SchoolForm.Where(sf => sf.SchoolId == schoolId).ToList());
        }

        public ActionResult Teachers(int schoolId = 0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            ViewBag.BodyTitle = "Учителя";
            return View();
        }

        public ActionResult Contacts(int schoolId = 0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            ViewBag.BodyTitle = "Контакты";
            return View();
        }

        public ActionResult Pupils(int schoolId = 0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            ViewBag.BodyTitle = "Ученики";
            ViewBag.SchoolId = school.Id;
            return View(db.SchoolForm.Where(sf => sf.SchoolId == schoolId).ToList());
        }

        public ActionResult Docs(int schoolId = 0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            ViewBag.BodyTitle = "Документы";
            return View();
        }

        public PartialViewResult DropMenu(int SchoolId)
        {
            return PartialView(new DropMenu<School> { Id = SchoolId, list = db.School.ToList() });
        }
    }
}
