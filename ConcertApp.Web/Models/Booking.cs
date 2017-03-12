using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcertApp.Web.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ConcertId { get; set; }
        public int UserId { get; set; }
        public string Seats { get; set; }
        public decimal Price { get; set; }
    }
}