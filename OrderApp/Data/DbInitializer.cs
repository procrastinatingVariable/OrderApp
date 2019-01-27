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
                new Restaurant{Email = "user@test.co", Password = "password", Address = "Address", Name = "cico" },
                new Restaurant{Email = "user2@test.co", Password = "password", Address = "Address2", Name = "loco pub" }
            };

            foreach (var restaurant in restaurants)
            {
                context.Restaurant.Add(restaurant);
            }

            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{CreationTime = new DateTime(2019, 09, 21, 20, 30, 10), restaurant = restaurants[0] },
                new Order{CreationTime = new DateTime(2019, 09, 22, 20, 30, 10), restaurant = restaurants[0] },
                new Order{CreationTime = new DateTime(2019, 09, 23, 20, 30, 10), restaurant = restaurants[0] },
            };

            foreach (var order in orders)
            {
                context.Order.Add(order);
            }

            context.SaveChanges();

            context.AddRange(
                new OrderMenuItem { order = orders[0], menuItem = menuItems[0] },
                new OrderMenuItem { order = orders[0], menuItem = menuItems[1] },
                new OrderMenuItem { order = orders[0], menuItem = menuItems[2] }
            );

            context.SaveChanges();



        }

    }
}
