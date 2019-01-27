using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApp.Model;

namespace OrderApp.Models
{
    public class OrderAppContext : DbContext
    {
        public OrderAppContext (DbContextOptions<OrderAppContext> options)
            : base(options)
        {
        }

        public DbSet<OrderApp.Model.MenuItem> MenuItem { get; set; }

        public DbSet<OrderApp.Model.Order> Order { get; set; }

        public DbSet<OrderApp.Model.Restaurant> Restaurant { get; set; }

        public DbSet<OrderApp.Model.Admin> Admin { get; set; }

        public DbSet<OrderApp.Model.Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderMenuItem>()
                .HasKey(om => new { om.OrderId, om.MenuItemId });

            modelBuilder.Entity<OrderMenuItem>()
                .HasOne(om => om.order)
                .WithMany(o => o.Items)
                .HasForeignKey(om => om.OrderId);

            modelBuilder.Entity<OrderMenuItem>()
                .HasOne(om => om.menuItem)
                .WithMany(mi => mi.Orders)
                .HasForeignKey(om => om.MenuItemId);
        }

    }
}
