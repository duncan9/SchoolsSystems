using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;
using schoolsSystems.Models.DropMenu;

namespace schoolsSystems.Controllers
{
    public class FormLetterController : Controller
    {
       EMEntities db;
        public FormLetterController(){
            db=new EMEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DropMenu(int FormLetterId)
        {
            return PartialView(new DropMenu<FormLetter> { Id = FormLetterId, list = db.FormLetter.ToList() });
        }

    }
}
