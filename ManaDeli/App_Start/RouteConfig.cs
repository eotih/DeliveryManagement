using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ManaDeli
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
                   name: "Cập nhật thông tin",
                   url: "tai-khoan/cap-nhat-thong-tin",
                   defaults: new { controller = "Account", action = "UpdateUser", id = UrlParameter.Optional }
               );
        }
    }
}
