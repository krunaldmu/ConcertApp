using System;

namespace ConcertApp.Web.Models
{
    public class Concert
    {
        public int ConcertId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string DateTime { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }
}