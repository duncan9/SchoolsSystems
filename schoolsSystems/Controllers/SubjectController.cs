using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;

namespace schoolsSystems.Controllers
{
    public class SubjectController : Controller
    {
        EMEntities db;
        public SubjectController(){
            db=new EMEntities();
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
