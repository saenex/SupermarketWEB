using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SupermarketWEB.Pages.User
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<SupermarketWEB.Models.User> Users { get; set; } = new List<SupermarketWEB.Models.User>();


        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync<SupermarketWEB.Models.User>();

        }
    }
}
