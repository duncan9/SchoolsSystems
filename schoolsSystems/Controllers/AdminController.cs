using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using schoolsSystems.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Web.Security;

namespace schoolsSystems.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        public ActionResult Index()
        {
            List<ApplicationUser> list = UserManager.Users.ToList();
            ViewBag.BodyTittle = "Список юзеров";
            return View(list);
        }

    }
}
