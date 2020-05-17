using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Digoel.Encryption;
using Digoel.Models;
using Microsoft.AspNet.Identity;

namespace Digoel.Controllers
{
    [Authorize]
    public class PasswordStorageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            // Here we get current logged in users id
            string current_logged_in_user_id = User.Identity.GetUserId();

            // this linq query show all the storage password information for the logged in user only
            var result = (from s in db.GetPasswordStorage
                          where s.UserId == current_logged_in_user_id
                          select new
                          {
                              id = s.Id,
                              Website = s.Website,
                              Password = s.Password,
                              DateSaved = s.DateSaved
                          }).AsEnumerable().Select(a => new PasswordStorage
                          {
                              Id = a.id,
                              Website = a.Website,
                              Password = AdvancedEncryptionStandard.DecryptText(a.Password),
                              DateSaved = a.DateSaved

                          }).ToList();

            return View(result);
        }


    


        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PasswordStorage passwordStorage = db.GetPasswordStorage.Find(id);

            passwordStorage.Password = AdvancedEncryptionStandard.DecryptText(passwordStorage.Password);

            if (passwordStorage == null)
            {
                return HttpNotFound();
            }
            return View(passwordStorage);
        }


        [HttpGet]
        public ActionResult Create()
        {
            string generated_password = string.Empty;

            if (Session["generated_password"] != null)
            {
                generated_password = Session["generated_password"].ToString();
            }

            if (string.IsNullOrEmpty(generated_password))
            {
                return View();
            }
            else
            {
                Session["generated_password"] = generated_password;
                return View();
            }

        }


        [HttpPost]
        public ActionResult GivenPassword(string generated_password)
        {
            Session["generated_password"] = generated_password;
            return RedirectToAction("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Website,Password,DateSaved")] PasswordStorage passwordStorage)
        {
            if (ModelState.IsValid)
            {
                // Here we get current logged in users id
                string current_logged_in_user_id = User.Identity.GetUserId();

                passwordStorage.Password = AdvancedEncryptionStandard.EncryptText(passwordStorage.Password);
                passwordStorage.DateSaved = DateTime.Now;
                passwordStorage.UserId = current_logged_in_user_id; // here pass current loggedin user id for insert the value
                db.GetPasswordStorage.Add(passwordStorage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passwordStorage);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(Session["result_password"] == null){
                PasswordStorage passwordStorage = db.GetPasswordStorage.Find(id);
                passwordStorage.Password = AdvancedEncryptionStandard.DecryptText(passwordStorage.Password);
                if (passwordStorage == null)
                {
                    return HttpNotFound();
                }
                return View(passwordStorage);
            }
            else
            {

                PasswordStorage passwordStorage = db.GetPasswordStorage.Find(id);
                passwordStorage.Password = Session["result_password"].ToString();
                if (passwordStorage == null)
                {
                    return HttpNotFound();
                }
                return View(passwordStorage);
            }
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Website,Password,DateSaved")] PasswordStorage passwordStorage)
        {
            if (ModelState.IsValid)
            {
                // Here we get current logged in users id
                string current_logged_in_user_id = User.Identity.GetUserId();

                passwordStorage.Password = AdvancedEncryptionStandard.EncryptText(passwordStorage.Password);
                passwordStorage.DateSaved = DateTime.Now;
                passwordStorage.UserId = current_logged_in_user_id; // here pass current loggedin user id for update the value
                db.Entry(passwordStorage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passwordStorage);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PasswordStorage passwordStorage = db.GetPasswordStorage.Find(id);
            passwordStorage.Password = AdvancedEncryptionStandard.DecryptText(passwordStorage.Password);
            if (passwordStorage == null)
            {
                return HttpNotFound();
            }
            return View(passwordStorage);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PasswordStorage passwordStorage = db.GetPasswordStorage.Find(id);
            db.GetPasswordStorage.Remove(passwordStorage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
