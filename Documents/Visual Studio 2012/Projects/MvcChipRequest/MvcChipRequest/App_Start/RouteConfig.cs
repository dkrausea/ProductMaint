using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcChipRequest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GTW",
                url: "GTW",
                defaults: new { controller = "ChipRequest", action = "GTW" }
            );
            routes.MapRoute(
                name: "chip",
                url: "chip",
                defaults: new { controller = "Chip", action = "Index" }
            );

            routes.MapRoute(
                name: "demandStatus",
                url: "demandStatus",
                defaults: new { controller = "DemandStatus", action = "Index" }
           );

            routes.MapRoute(
                name: "active",
                url: "active",
                defaults: new { controller = "Home", action = "Active"}
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}