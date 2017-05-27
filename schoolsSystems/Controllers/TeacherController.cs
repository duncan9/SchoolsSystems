using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;

namespace schoolsSystems.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        EMEntities db;
        public TeacherController()
        {
            db=new EMEntities();
        }
        public ActionResult Index(int schoolId=0)
        {
            List<Teacher> teachers = db.Teacher.Where(t => t.SchoolId == schoolId).ToList();
            return View(teachers);
        }

    }
}
