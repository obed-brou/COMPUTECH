using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace COMPUTECH.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        // Muestra la p�gina de confirmaci�n de cierre de sesi�n
        public void OnGet()
        {
        }

        // Maneja el POST para cerrar sesi�n
        public async Task<IActionResult> OnPostAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index"); // Redirige a la p�gina de inicio despu�s de cerrar sesi�n
        }
    }
}
