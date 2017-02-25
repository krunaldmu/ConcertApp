using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ConcertApp.Web.Models;

namespace ConcertApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private ConcertApp.Web.Models.ConcertAppContext db = new ConcertAppContext();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Index()
        {
            using (ConcertAppContext db = new ConcertAppContext())
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public string Login(User user)
        {
            using (ConcertAppContext db = new ConcertAppContext())
            {
                var usr = db.Users.Single(u => u.FirstName == user.FirstName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["EmailAddress"] = usr.EmailAddress.ToString();
                    return RedirectToAction("LoggedIn").ToString();
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Incorrect");
                }
            }
            return View().ToString();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("SignIn");
            }
        }

        [HttpPost]
        public string RegisterUser(ConcertAppContext context)
        {
            string firstName = Request["firstName"];
            string lastName = Request["lastname"];
            string email = Request["email"];
            string password = Request["password"];
            string mobileNumber = Request["mobileNumber"];

            try
            {
                User user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = email,
                    Password = password,
                    MobileNumber = mobileNumber
                };
                
                context.Users.AddOrUpdate(user);
                context.SaveChanges();
              
            }
            catch
            {

            }
            
            return "User Registered Successfully";
        }

        [HttpPost]
        public bool AuthenticateUser(ConcertAppContext context)
        {
            string email = Request["email"];
            string password = Request["password"];

            var user = context.Users.FirstOrDefault(x => x.EmailAddress == email);

            var isPasswordCorrect = user != null && user.Password.Equals(password);

            if (isPasswordCorrect == false)
            {
                return false;
            }
            else
            {
                Session["fullname"] = user.FirstName + " " + user.LastName;
                Session["emailAddress"] = user.EmailAddress;
                Session["isAdmin"] = user.IsAdmin;

                return true;
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User User = db.Users.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User User = db.Users.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User User = db.Users.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "UserId, FirstName, Lastname, Password, EmailAddress, MobileNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public bool SignOut()
        {
            Session.Abandon();

            return true;
        }
    }
}