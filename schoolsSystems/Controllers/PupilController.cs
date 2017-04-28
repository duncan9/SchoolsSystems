using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;

namespace schoolsSystems.Controllers
{
    public class PupilController : Controller
    {
        EMEntities db;
        public PupilController()
        {
            db = new EMEntities();
        }
        public ActionResult Index(int schoolId=0,int SchoolFormId=0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            List<Pupil> pupils = db.Pupil.Where(p => p.SchoolId == schoolId && p.SchoolFormId == SchoolFormId).ToList();
            ViewBag.SchoolFormId = SchoolFormId;
            ViewBag.SchoolId = school.Id;
            ViewBag.BodyTitle = "Список учеников";
            return View(pupils);
        }
        public ActionResult Edit(Pupil pupil)
        {
            if (ModelState.IsValid)
            {
                db.Pupil.Add(pupil);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new {SchoolId=pupil.SchoolId,SchoolFormId=pupil.SchoolFormId });
        }
        public ActionResult Create(int schoolId=0,int SchoolFormId=0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            ViewBag.BodyTitle = "Редактирование ученика";
            Pupil p = new Pupil();
            p.SchoolId = schoolId;
            p.SchoolFormId=SchoolFormId;
            return View("Edit", p);
        }

    }
}
