using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Invoice Invoice { get; set; } = default!;

        public void OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName");
            ViewData["PayModeId"] = new SelectList(_context.PayModes, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Invoice == null)
            {
                ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", Invoice?.CustomerId);
                ViewData["PayModeId"] = new SelectList(_context.PayModes, "Id", "Name", Invoice?.PayModeId);
                return Page();
            }

            _context.Invoices.Add(Invoice);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}