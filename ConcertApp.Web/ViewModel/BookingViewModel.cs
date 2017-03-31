using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcertApp.Web.ViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public string ConcertName { get; set; }
        public string Username { get; set; }
        public string Seats { get; set; }
        public decimal Price { get; set; }
    }
}