using Application.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PlayCourt.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterPlayerViewModel Input { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: Call Application Service (e.g., IIdentityService.RegisterAsync)
            // Lưu ý: Tuyệt đối không gọi DB context/Repository trực tiếp tại đây.

            return RedirectToPage("/Player/Dashboard");
        }
    }
}