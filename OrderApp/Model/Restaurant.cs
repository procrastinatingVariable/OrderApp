using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    public class Restaurant : User
    {

        public string Name { get; set; }

        public string Address { get; set; }


        public ICollection<Order> Orders;
        public ICollection<MenuItem> MenuItems;

    }
}
