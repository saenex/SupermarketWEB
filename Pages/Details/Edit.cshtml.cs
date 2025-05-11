using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Details
{
    public class EditModel : PageModel
    {
        private readonly SupermarketContext _context;

        public EditModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Detail Detail { get; set; } = default!;

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

            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id");
                ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
                return Page();
            }

            _context.Attach(Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Details.Any(e => e.Id == Detail.Id))
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
    }
}
