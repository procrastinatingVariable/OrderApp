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

        public async Task OnGetAsync()
        {
            Order = await _context.Order.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);
            order.CompletionTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
