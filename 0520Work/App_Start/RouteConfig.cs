using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _0520Work
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/

            //最初執行時
            routes.MapRoute(
                name: "/",
                url: "",
                defaults: new { Controller = "Home", Action = "NFU" }
            );

            //NFU
            routes.MapRoute(
                name: "NFU",
                url: "NFU",
                defaults: new { Controller = "Home", Action = "NFU" }
            );
        }
    }
}
