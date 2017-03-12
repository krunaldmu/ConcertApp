using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcertApp.Web.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int SeatId { get; set; }
        public int ConcertId { get; set; }
        public int UserId { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
    }
}