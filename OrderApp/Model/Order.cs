using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    public class Order
    {

        public int ID { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? CompletionTime { get; set; }

        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        public ICollection<OrderMenuItem> MenuItemsLink { get; set; } = new List<OrderMenuItem>();

        public ICollection<MenuItem> GetMenuItems()
        {
            return MenuItemsLink.Select(item => item).Where(item => item.OrderId == ID).Select(orderMenuItem => orderMenuItem.MenuItem).ToList();
        }

        public void AddMenuItem(MenuItem item)
        {
            OrderMenuItem linkItem = new OrderMenuItem { OrderId = ID, Order = this, MenuItem = item, MenuItemId = item.ID };
            MenuItemsLink.Add(linkItem);
        }

    }
}
