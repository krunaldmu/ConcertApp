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
    }
}