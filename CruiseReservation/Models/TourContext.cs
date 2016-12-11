using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CruiseReservation.Models
{
    public class TourContext : DbContext
    {
        public TourContext() : base("CruiseReservation")
        {
        }
        public DbSet<Cruise> Cruises { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Cabin> Cabin { get; set; }
    }
}