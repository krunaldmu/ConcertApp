using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcertApp.Web.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int Row { get; set; }
        public string Column { get; set; }
    }
}