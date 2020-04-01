using Digoel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Digoel.Controllers
{
    [Authorize]
    public class PasswordGenController : Controller
    {
     
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string selected_type, string selected_length)
        {
            var generated_password = string.Empty;

            if (selected_type == "1") //Think Random
            {
                generated_password = Generate.Words(3);
            }
            else if (selected_type == "2") //Pure Random
            {
                int length = Convert.ToInt32(selected_length);
                if (length < 8)
                {
                    var length_message = "Minimum length should be eight";
                    generated_password = "";
                    return Json(new { length_message = length_message, generated_password = generated_password }, JsonRequestBehavior.AllowGet);
                }
                generated_password = PureRandom.GeneratePass(length);
            }
            else //Numbers
            {
                generated_password = generate_random_number(Convert.ToInt32(selected_length));
            }

            return Json(new { generated_password = generated_password }, JsonRequestBehavior.AllowGet);
        }


        public string generate_random_number(int length)
        {
            var rndDigits = new System.Text.StringBuilder().Insert(0, "0123456789", length).ToString().ToCharArray();
            return string.Join("", rndDigits.OrderBy(o => Guid.NewGuid()).Take(length));
        }


        [HttpGet]
        public ActionResult CustomizePasswordGenerate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomizePasswordGenerate(string length, string is_checked_include_symbol, string is_checked_include_number, string is_checked_include_uppercase, string is_checked_include_lowercase)
        {
            bool include_symbol = Convert.ToBoolean(is_checked_include_symbol);
            bool include_number = Convert.ToBoolean(is_checked_include_number);
            bool include_uppercase = Convert.ToBoolean(is_checked_include_uppercase);
            bool include_lowercase = Convert.ToBoolean(is_checked_include_lowercase);

           var generated_password =  CustonizePasswordGenerator.GeneratePassword(include_lowercase, include_uppercase, include_number, include_symbol, false, Convert.ToInt32(length));

            return Json(new { generated_password = generated_password }, JsonRequestBehavior.AllowGet);
        }

    }
}