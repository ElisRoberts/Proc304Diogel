using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digoel.Filters;


namespace Digoel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //ReCaptcha error and action handling 
        public ActionResult CaptchaRoute(string secret, string format)
        {

            if (secret != "special")
                return new HttpStatusCodeResult(403);

            if (format == "text")
                return Content("bdtext");
            else if (format == "json")
                return Json(new { password = "bdpassword", expires = DateTime.UtcNow.ToShortDateString() }, JsonRequestBehavior.AllowGet);
            else if (format == "clean")
                return PartialView();
            return View();
        }
    }
}