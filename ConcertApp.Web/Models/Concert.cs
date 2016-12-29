using System;

namespace ConcertApp.Web.Models
{
    public class Concert
    {
        public int ConcertId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}