using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ConcertApp.Web.Models;

namespace ConcertApp.Web.Controllers
{
    public class BookingsController : Controller
    {
        private ConcertAppContext db = new ConcertAppContext();
        //private ConcertApp.Web.Models.ConcertAppContext db = new ConcertAppContext();

        // GET: Bookings
        public ActionResult Index()
        {
            int userid = -1;
            if (Session["UserID"].ToString() != null)
            {
                userid = Convert.ToInt16(Session["UserID"].ToString());
                return View(db.Bookings.Where(b => b.UserId == userid).ToList());
            }
            return View(db.Bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            var concert = (from m in db.Concerts select m).ToList();

            ViewBag.Concert = concert;

            ViewBag.ConcertId = TempData["ConcertId"];
            ViewBag.ConcertName = TempData["ConcertName"];

            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Create([Bind(Include = "BookingId,ConcertId,UserId,Seats,Price")] Booking Booking)
        {
            if (ModelState.IsValid)
            {
                Booking.UserId = Convert.ToInt16(Session["UserId"]);
                db.Bookings.Add(Booking);
                db.SaveChanges();

                string email = @Session["EmailAddress"].ToString();

                int userId = Convert.ToInt16(@Session["UserID"].ToString());

                string name = (from n in db.Users
                    where n.UserId == userId
                    select n.FirstName + " " + n.LastName).SingleOrDefault();
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress("concertapp24@gmail.com");
                    mail.Subject = "CSRS Concert Seat Reservation Confirmation";
                    mail.Body = "Hi " + name;
                    mail.Body += "<p> Booking is Confirmed For - " +
                                db.Concerts.Where(m => m.ConcertId == Booking.ConcertId)
                                    .SingleOrDefault()
                                    .Title.ToString() + "</p>";
                    mail.Body += "<p>Seat Booked - " + Booking.Seats + "</p>";
                    mail.Body += "<p>You Have Paid - &pound;" + Booking.Price + "</p>";
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Credentials = new NetworkCredential("concertapp24@gmail.com","myconcertapp");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {

                }
                //return View(Booking);
                TempData["message"] = "Booking Successfully. You Should Get Email Confirmation Shortly.";
                return RedirectToAction("Index" , "Home");
            }
            return RedirectToAction("Create", "Bookings");
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,ConcertId,UserId,Seats,Price")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
