using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    public class Order
    {

        public int ID { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? CompletionTime { get; set; }

        public Restaurant restaurant { get; set; }


        public ICollection<OrderMenuItem> Items { get; set; } = new List<OrderMenuItem>();

        public ICollection<MenuItem> GetMenuItems()
        {
            return Items.Select(item => item).Where(item => item.OrderId == ID).Select(orderMenuItem => orderMenuItem.menuItem).ToList();
        }

        public void AddMenuItem(MenuItem item)
        {
            OrderMenuItem linkItem = new OrderMenuItem { OrderId = ID, order = this, menuItem = item, MenuItemId = item.ID };
            Items.Add(linkItem);
        }

    }
}
