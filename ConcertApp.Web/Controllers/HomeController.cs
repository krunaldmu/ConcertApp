using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConcertApp.Web.Models;

namespace ConcertApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private ConcertApp.Web.Models.ConcertAppContext db = new ConcertAppContext();

        public ActionResult Index()
        {
            return View(db.Concerts.ToList());
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
    }
}