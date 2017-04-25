using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schoolsSystems.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.BodyTitle = "Главная";
            return View();
        }
        public ActionResult Info()
        {
            ViewBag.BodyTitle = "О нас";
            return View();
        }
        public ActionResult News()
        {
            ViewBag.BodyTitle = "Новости";
            return View();
        }
        public ActionResult Contacts()
        {
            ViewBag.BodyTitle = "Контакты";
            return View();
        }
    }
}
