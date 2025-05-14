using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Details
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Detail? Detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Details == null)
            {
                return NotFound();
            }

            Detail = await _context.Details
                .Include(d => d.Invoice)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Detail == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Details == null)
            {
                return NotFound();
            }

            Detail = await _context.Details.FindAsync(id);

            if (Detail != null)
            {
                _context.Details.Remove(Detail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
