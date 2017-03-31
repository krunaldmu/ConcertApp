using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConcertApp.Web.Models;

namespace ConcertApp.Web.Services
{
    public class ConcertService
    {
        ConcertAppContext db = new ConcertAppContext();

        public ConcertService()
        {
            
        }

        public string GetConcertName(int concertId)
        {
            var firstOrDefault = db.Concerts.FirstOrDefault(x => x.ConcertId == concertId);
            if (firstOrDefault != null)
                return firstOrDefault.Title;
            else
            {
                return "";
            }
        }
    }
}