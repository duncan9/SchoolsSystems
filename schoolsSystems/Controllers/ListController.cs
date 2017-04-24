using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;

namespace schoolsSystems.Controllers
{
    public class ListController : Controller
    {
        EMEntities db;
        public ListController()
        {
            db = new EMEntities();
        }
        //
        // GET: /List/

        public PartialViewResult Subject()
        {
            return PartialView();
        }

    }
}
