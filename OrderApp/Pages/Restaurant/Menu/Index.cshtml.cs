using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderApp.Model;
using OrderApp.Models;

namespace OrderApp.Pages.Restaurant.Menu
{
    public class IndexModel : PageModel
    {
        private readonly OrderApp.Models.OrderAppContext _context;

        public IndexModel(OrderApp.Models.OrderAppContext context)
        {
            _context = context;
        }

        public int? ID { get; set; }

        public IList<MenuItem> MenuItem { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            ID = id;
            IList<MenuItem> items = await _context.MenuItem.ToListAsync();
            items = items.Select(item => item).Where(item => item.Restaurant.ID == id).ToList();

            if (items == null)
            {
                return NotFound();
            }

            MenuItem = items;

            return Page();

        }
    }
}
