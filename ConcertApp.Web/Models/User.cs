using System;
using System.ComponentModel.DataAnnotations;

namespace ConcertApp.Web.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string MobileNumber { get; set; }
        public bool IsAdmin { get; set; }
    }
}
