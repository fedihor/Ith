using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ith.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Posts",
                url: "Post/Index/{page}",
                defaults: new { controller = "Post", action = "Index", page = 1 },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Post",
                url: "Post/Index/{id}/{page}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional, page = 1 },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
