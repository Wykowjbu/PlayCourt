using Application.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Auth
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public ForgotPasswordViewModel Input { get; set; } = new();

        public void OnGet()
        {
            // Reset state
            Input.IsOtpSent = false;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: Gọi Application Service để gửi OTP
            // await _authService.SendOtpAsync(Input.Email);



            return Page();
        }

        public async Task<IActionResult> OnPostResendAsync()
        {
            // Logic gửi lại OTP
            // Giữ trạng thái IsOtpSent = true
            Input.IsOtpSent = true;
            return Page();
        }
    }
}

