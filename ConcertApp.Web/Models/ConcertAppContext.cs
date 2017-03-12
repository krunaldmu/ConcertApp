using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConcertApp.Web.Models
{
    public class ConcertAppContext : DbContext
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}