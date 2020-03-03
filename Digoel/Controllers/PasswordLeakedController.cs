using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HaveIBeenPwned.Password;

namespace Digoel.Controllers
{
    public class PasswordLeakedController : Controller
    {
        // GET: PasswordLeaked
        public ActionResult LeakedView()
        {
            return View();
        }

        // POST: PasswordLeaked
        [HttpPost]
        public ActionResult Check(string Password)
        {
            var pwned = new HaveIBeenPwned.Password.HaveIBeenPwned();
            bool isPasswordLeaked = pwned.IsPasswordPwned(Password);

            if (isPasswordLeaked == true)
            {
                Response.Write("<script> alert ('This password has been leaked');</script>");
            }
            else
            {
                Response.Write("<script> alert ('This password has NOT been leaked');</script>");
            }
            return View("LeakedView");
              
        }
    }
}


