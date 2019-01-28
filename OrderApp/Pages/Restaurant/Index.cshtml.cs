using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderApp.Model;
using OrderApp.Models;

namespace OrderApp.Pages.Restaurant
{
    public class IndexModel : PageModel
    {
        private readonly OrderApp.Models.OrderAppContext _context;

        public IndexModel(OrderApp.Models.OrderAppContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task<IActionResult> OnGetAsync(int? restaurantId)
        {
            if (restaurantId == null)
            {
                return NotFound();
            }

            var order = await _context.Order.Include(o => o.Restaurant)
                .Select(o => o)
                .Where(o => o.Restaurant.ID == restaurantId)
                .ToListAsync();

            if (order == null)
            {
                return NotFound();
            }

            Order = order;

            return Page();

        }

        [BindProperty]
        public int ID { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            Order order = await _context.Order.FirstOrDefaultAsync(m => m.ID == ID);
            order.CompletionTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
