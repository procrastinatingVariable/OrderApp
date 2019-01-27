using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderApp.Model;
using OrderApp.Models;

namespace OrderApp.Pages.Restaurant.Menu
{
    public class AddModel : PageModel
    {
        private readonly OrderApp.Models.OrderAppContext _context;

        public AddModel(OrderApp.Models.OrderAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Restaurant Restaurant { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = _context.Restaurant.Find(id);

            if (Restaurant == null)
            {
                return NotFound();
            }

            return Page();
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Restaurant.MenuItems.Add(MenuItem);
            _context.MenuItem.Add(MenuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}