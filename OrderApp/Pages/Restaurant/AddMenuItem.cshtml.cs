using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderApp.Model;

namespace OrderApp.Pages.Restaurant
{
    public class AddMenuItemModel : PageModel
    {
        private readonly OrderApp.Models.OrderAppContext _context;


        public AddMenuItemModel(OrderApp.Models.OrderAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        [BindProperty]
        public int MenuItemId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MenuItem menuItem = await _context.MenuItem.FirstOrDefaultAsync(m => m.ID == MenuItemId);

            if (menuItem == null)
            {
                return NotFound();
            }

            Order.AddMenuItem(menuItem);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}