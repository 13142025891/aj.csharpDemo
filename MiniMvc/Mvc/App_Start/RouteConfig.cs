using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "GetAll" }

            );

            routes.MapRoute(
              name: "Detail",
              url: "{name}/{id}",
              defaults: new { controller = "Home", action = "GetById" }

          );
        }
    }
}
