using Microsoft.EntityFrameworkCore;
using OrderApp.Model;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Data
{
    public class DbInitializer
    {

        public static void Initialize(OrderAppContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            var customers = new Customer[]
            {
                new Customer {Email = "customer@test.co", Name = "Customer1", Password = "password" },
                new Customer {Email = "customer2@test.co", Name = "Customer2", Password = "password" }
            };

            foreach (var customer in customers)
            {
                context.Customer.Add(customer);
            }

            context.SaveChanges();


            var menuItems = new MenuItem[]
            {
                new MenuItem{Name="Menuitem1", Description = "Delicious food1", Price = 23.5 },
                new MenuItem{Name="Menuitem2", Description = "Delicious food2", Price = 23.5 },
                new MenuItem{Name="Menuitem3", Description = "Delicious food3", Price = 23.5 },
                new MenuItem{Name="Menuitem4", Description = "Delicious food4", Price = 23.5 },
                new MenuItem{Name="Menuitem5", Description = "Delicious food5", Price = 23.5 },
                new MenuItem{Name="Menuitem6", Description = "Delicious food6", Price = 23.5 },
                new MenuItem{Name="Menuitem7", Description = "Delicious food7", Price = 23.5 }
            };

            foreach (var menuItem in menuItems)
            {
                context.MenuItem.Add(menuItem);
            }

            context.SaveChanges();


            var restaurants = new Restaurant[]
{
                new Restaurant
                {
                    Email = "user@test.co",
                    Password = "password",
                    Address = "Address",
                    Name = "cico",
                    MenuItems = new List<MenuItem>()
                    {
                        menuItems[0],
                        menuItems[1],
                        menuItems[2]
                    }
                },
                new Restaurant{Email = "user2@test.co", Password = "password", Address = "Address2", Name = "loco pub" }
};

            foreach (var restaurant in restaurants)
            {
                context.Restaurant.Add(restaurant);
            } 

            context.SaveChanges();


            var orders = new Order[]
            {
                new Order{CreationTime = new DateTime(2019, 09, 21, 20, 30, 10), Restaurant = restaurants[0], Customer = customers[0] },
                new Order{CreationTime = new DateTime(2019, 09, 22, 20, 30, 10), Restaurant = restaurants[0], Customer = customers[1] },
                new Order{CreationTime = new DateTime(2019, 09, 23, 20, 30, 10), Restaurant = restaurants[0], Customer = customers[1] }
            };
            orders[0].MenuItemsLink.Add(new OrderMenuItem { Order = orders[0], MenuItem = menuItems[0] });
            orders[0].MenuItemsLink.Add(new OrderMenuItem { Order = orders[0], MenuItem = menuItems[1] });

            foreach (var order in orders)
            {
                context.Order.Add(order);
            }

            context.SaveChanges();


        }

    }
}
