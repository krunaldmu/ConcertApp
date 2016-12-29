using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConcertApp.Web.Models;

namespace ConcertApp.Web.Controllers
{
    public class ConcertController : Controller
    {
        // GET: Concert
        public ActionResult AddConcert()
        {
            return View();
        }

        [HttpPost]
        public string AddingConcert(ConcertAppContext context)
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
            return "Concert Added Successfully";
        }
    }
}