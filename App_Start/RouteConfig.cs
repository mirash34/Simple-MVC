using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace study
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Card",
                url: "card/{IdVar}",
                defaults: new { controller = "Home", action = "Card", IdVar = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Index",
                url: "index/{Property}/{Direction}/{NumberOfPage}",
                defaults: new { controller = "Home", action = "Index",Property=UrlParameter.Optional, Direction=UrlParameter.Optional, NumberOfPage = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
