using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Details
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Detail> Details { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Details = await _context.Details
                .Include(d => d.Invoice)
                .Include(d => d.Product)
                .ToListAsync();
        }
    }
}
