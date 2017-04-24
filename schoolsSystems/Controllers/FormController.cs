using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;
using schoolsSystems.Models.DropMenu;

namespace schoolsSystems.Controllers
{
    public class FormController : Controller
    {
        EMEntities db;
        //
        // GET: /Form/
        public FormController(){
            db=new EMEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult List(int schoolId)
        {
            List<Form> forms = db.Form.ToList();
            ViewBag.schoolId = schoolId;
            return PartialView(forms);
        }
        public PartialViewResult DropMenu(int formId)
        {
            return PartialView(new FormDropMenu { FormId= formId, forms = db.Form.ToList() });
        }
    }
}
