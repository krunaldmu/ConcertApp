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

        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Title")
            {
                return View(db.Concerts.Where(x => x.Title.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "Category")
            {
                return View(db.Concerts.Where(x => x.Category.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.Concerts.ToList());
            }
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