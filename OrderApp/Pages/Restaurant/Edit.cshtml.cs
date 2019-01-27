using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderApp.Model;
using OrderApp.Models;

namespace OrderApp.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        private readonly OrderApp.Models.OrderAppContext _context;

        public EditModel(OrderApp.Models.OrderAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.ID == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(Restaurant.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RestaurantExists(string id)
        {
            return _context.Restaurant.Any(e => e.Email == id);
        }
    }
}
