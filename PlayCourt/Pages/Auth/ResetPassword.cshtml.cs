using Application.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Auth
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public ResetPasswordViewModel Input { get; set; } = new();

        public void OnGet(string token, string email)
        {
            // Tự động điền token và email vào form ẩn để submit
            Input.Token = token;
            Input.Email = email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Gọi Application Service để Reset Password
            // var result = await _authService.ResetPasswordAsync(Input);

            // if (result.Succeeded) 
            //    return RedirectToPage("/Auth/Login");

            // Nếu lỗi, thêm vào ModelState
            // ModelState.AddModelError(string.Empty, "Failed to reset password.");

            return Page();
        }
    }
}
