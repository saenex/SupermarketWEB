using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        public SelectList Categories { get; set; } = default!;

        public void OnGet()
        {
            Categories = new SelectList(_context.Categories, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        { 
        if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("./Index");

        }
    }
}
