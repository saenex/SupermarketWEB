using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SupermarketWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SupermarketContext _context;

        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Se valida el usuario y contraseña en base a la BD
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == User.Email && u.Password == User.Password);

            if (user != null)
            {
                // Se crea los Claim, datos a almacenar en la Cookie
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                // Se asocia los clains a un nombre de Cookies
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                // Se agrega la entidad creada al ClaimsPrincipal de la aplicación
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Se registra exitosamente la autenticación y se crea la cookie en el navegador
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
            }

            // Si no se encuentra el usuario, se agrega un error al modelo
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return Page();
        }
    }

    public class User   
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}