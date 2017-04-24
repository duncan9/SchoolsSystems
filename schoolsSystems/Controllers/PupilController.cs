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
        public ActionResult Index(int SchoolId=0,int SchoolFormId=0)
        {
            List<Pupil> pupils = db.Pupil.Where(p => p.SchoolId == SchoolId && p.SchoolFormId == SchoolFormId).ToList();
            ViewBag.SchoolId = SchoolId;
            ViewBag.SchoolFormId = SchoolFormId;
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
        public ActionResult Create(int SchoolId=0,int SchoolFormId=0)
        {
            Pupil p = new Pupil();
            p.SchoolId = SchoolId;
            p.SchoolFormId=SchoolFormId;
            return View("Edit", p);
        }

    }
}
