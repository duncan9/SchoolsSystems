using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace schoolsSystems
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                null,// Route name
            "{controller}/{action}/{SchoolId}",                           // URL with parameters
            new { controller = "Form", action = "List", SchoolId = 0 }  // Parameter defaults
            );
            routes.MapRoute( 
                null,// Route name
            "{controller}/{action}/{SchoolId}/{SchoolFormId}",                           // URL with parameters
            new { controller = "Pupil", action = "Index", SchoolId = 0, SchoolFormId = 0}  // Parameter defaults
            );
            
        }
    }
}