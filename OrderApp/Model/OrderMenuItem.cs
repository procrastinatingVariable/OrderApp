using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    public class OrderMenuItem
    {

        public int OrderId { get; set; }
        public Order order { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem menuItem { get; set; }

    }
}
