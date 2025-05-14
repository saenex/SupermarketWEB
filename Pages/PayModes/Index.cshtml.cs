using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<PayMode> PayMode { get; set; } = default!;

        public async Task OnGetAsync()
        {
            PayMode = _context.PayModes.ToList();
        }
    }
}