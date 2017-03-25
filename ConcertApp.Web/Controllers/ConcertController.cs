using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConcertApp.Web.Models;

namespace ConcertApp.Web.Controllers
{
    public class ConcertController : Controller
    {
        private ConcertApp.Web.Models.ConcertAppContext db = new ConcertAppContext();
        // GET: Concert
        public ActionResult AddConcert()
        {
            return View();
        }

        //POST: Concert/Add
        [HttpPost]
        public RedirectToRouteResult Create(ConcertAppContext context)
        {
            string name = Request["name"];
            string category = Request["category"];
            string dateTime = Request["dateTime"];
            string location = Request["location"];
            string price = Request["price"];
            string description = Request["description"];

            try
            {
                Concert concert = new Concert
                {
                    Title = name,
                    Category = category,
                    Location = location,
                    Description = description
                };

                concert.DateTime = DateTime.Parse(dateTime);
                concert.Price = decimal.Parse(price);

                context.Concerts.AddOrUpdate(concert);
                context.SaveChanges();

            }
            catch
            {

            }
            TempData["success"] = "Concert Added Successfully";
            return RedirectToAction("Index", "Concert");
        }

        // GET: Concert/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert Concert = db.Concerts.Find(id);
            if (Concert == null)
            {
                return HttpNotFound();
            }
            return View(Concert);
        }

        //POST: Concert/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ConcertId,Title,category,dateTime,location,price,description")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           //return RedirectToAction("Index");
            return View("Index");
        }

        //GET: Concert/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert concert = db.Concerts.Find(id);
            if (concert != null)
            {
                TempData["ConcertId"] = concert.ConcertId;
                TempData["ConcertName"] = concert.Title;
            }
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        //GET: Concert/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert Concert = db.Concerts.Find(id);
            if (Concert == null)
            {
                return HttpNotFound();
            }
            return View(Concert);
        }

        //POST: Concert/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)

        {
            Concert concert = db.Concerts.Find(id);
            db.Concerts.Remove(concert);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View( db.Concerts.ToList());
        }

//        public ActionResult SearchIndex(string searchBy, string search)
//        {
//            if (searchBy == "Category")
//                return View(db.Concerts.Where(x => x.Category == search || search == null).ToList());
//            else
//                return View(db.Concerts.Where(x => x.Title.StartsWith(search) || search == null).ToList());
//        }
    }
}