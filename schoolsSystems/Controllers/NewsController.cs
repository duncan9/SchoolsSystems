using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;

namespace schoolsSystems.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        EMEntities db;
        public NewsController()
        {
            db = new EMEntities();
        }

        public ActionResult Index( int SchoolId = 0 )
        {
            School school = db.School.FirstOrDefault(s => s.Id == SchoolId);
            ViewData.Add("school", school);
            List<News> list = db.News.Where(n => n.SchoolId == SchoolId).ToList();
            return View(list);
        }
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { SchoolId = news.SchoolId });
        }
        public ActionResult Create(int schoolId = 0)
        {
            School school = db.School.FirstOrDefault(s => s.Id == schoolId);
            ViewData.Add("school", school);
            ViewBag.BodyTitle = "Редактирование новостей";
            News p = new News();
            p.SchoolId = schoolId;
            return View("Edit", p);
        }
    }

}


