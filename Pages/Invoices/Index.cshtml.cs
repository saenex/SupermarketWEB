using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using Microsoft.EntityFrameworkCore;


namespace SupermarketWEB.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;
        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }
        public IList<Invoice> Invoices { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Invoices = await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.PayMode)
                .ToListAsync();
        }
    }
}
