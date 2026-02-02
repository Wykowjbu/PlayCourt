using Application.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Auth
{
    public class RegisterOwnerModel : PageModel
    {

        [BindProperty]
                public RegisterOwnerViewModel Input { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("/Owner/Dashboard");
        }
    }
}
