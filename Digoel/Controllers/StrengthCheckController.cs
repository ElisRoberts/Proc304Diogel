using Digoel.Encryption;
using Digoel.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Digoel.Controllers
{
   [Authorize]
    public class StrengthCheckController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index(int? id)
        {
            string current_logged_in_user_id = User.Identity.GetUserId();
            Session["result_password"] = null;
            Session["Id"] = null;
            var result = (from s in db.GetPasswordStorage
                          where s.UserId == current_logged_in_user_id
                          select new
                          {
                              id = s.Id,
                              Password = s.Password,
                            
                          }).AsEnumerable().Select(a => new PasswordStorage
                          {
                              Id = a.id,
                              Password = AdvancedEncryptionStandard.DecryptText(a.Password),

                          }).FirstOrDefault();

            if (id > 0)
            {
                var result_password = (from s in db.GetPasswordStorage
                                       where s.Id == id
                                       select new
                                       {
                                           id = s.Id,
                                           Password = s.Password,

                                       }).AsEnumerable().Select(a => new PasswordStorage
                                       {
                                           Id = a.id,
                                           Password = AdvancedEncryptionStandard.DecryptText(a.Password),

                                       }).FirstOrDefault();
                Session["Id"] = result_password.Id.ToString();
                Session["result_password"] = result_password.Password.ToString();
            }
 

            Session["Password"] = result.Password.ToString();
            return View();
        }


        public ActionResult GetPassword(int? id)
        {
            return View();
        }


    }
}