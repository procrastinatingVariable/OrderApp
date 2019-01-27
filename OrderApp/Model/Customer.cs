using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    public class Customer : User
    {

        public string Name { get; set; }


        public ICollection<Order> Orders { get; set; }
    }
}
