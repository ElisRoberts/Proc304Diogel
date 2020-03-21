using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Digoel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            //Route used for captcha
            routes.MapRoute(
                name: "CaptchaRoute",
                url: "CaptchaRoute/{secret}/{format}",
                defaults: new { controller = "Home", action = "CaptchaRoute", format = UrlParameter.Optional }
             );
        }
    }
}
