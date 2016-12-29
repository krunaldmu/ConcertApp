using System;

namespace ConcertApp.Web.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public bool IsAdmin { get; set; }
    }
}
