using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProxSenceWebProj
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "PSe", action = "Index",
                    //category = (string)null, page = 1
                }
            );
            routes.MapRoute(null,
                "Page{page}",
                new
                {
                    controller = "Portfolio",
                    action = "Portfolio",
                    category = (string)null
                },
                new
                {
                    page = @"\d+"
                }
                );
            routes.MapRoute(null,
                "{category}",
                 new
                 {
                     controller = "Portfolio",
                     action = "Portfolio",
                     page = 1
                 });
            routes.MapRoute(null,
                "{category}/Page{page}",
                 new
                 {
                     controller = "Portfolio",
                     action = "Portfolio",
                 },
                new
                {
                    page = @"\d+"
                });
            routes.MapRoute(null, "{controller}/{action}");
            
        }
    }
}

