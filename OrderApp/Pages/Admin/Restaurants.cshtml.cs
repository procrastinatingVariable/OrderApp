using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderApp.Model;
using OrderApp.Models;

namespace OrderApp.Pages.Admin
{
    public class RestaurantsModel : PageModel
    {
        private readonly OrderApp.Models.OrderAppContext _context;

        public RestaurantsModel(OrderApp.Models.OrderAppContext context)
        {
            _context = context;
        }

        public IList<Model.Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurant.ToListAsync();
        }
    }
}
