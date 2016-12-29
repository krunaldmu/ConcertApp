﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using ConcertApp.Web.Models;

namespace ConcertApp.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
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

        public bool SignOut()
        {
            Session.Abandon();

            return true;
        }
    }
}