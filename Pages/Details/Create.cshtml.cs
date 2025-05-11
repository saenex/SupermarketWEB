using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Details
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Detail Detail { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Detail == null)
            {
                ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", Detail?.InvoiceId);
                ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", Detail?.ProductId);
                return Page();
            }

            _context.Details.Add(Detail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
