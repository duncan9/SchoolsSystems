using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolsSystems.Models;

namespace schoolsSystems.Controllers
{
  
    public class CityController : Controller
    {
        EMEntities db;
        public CityController()
        {
            db = new EMEntities();
        }
        //
        // GET: /City/

        public PartialViewResult Index()
        {

            return PartialView(db.City.ToList());
        }
        public PartialViewResult DropMenu(int CityId)
        {
            return PartialView(new CityDropMenu { CityId = CityId, cities = db.City.ToList() });
        }
    }
}
