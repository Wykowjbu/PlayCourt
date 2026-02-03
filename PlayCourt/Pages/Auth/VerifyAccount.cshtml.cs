using Application.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Auth
{
    public class VerifyAccountModel : PageModel
    {
      
        [BindProperty]
        public VerifyAccountViewModel VerifyVM { get; set; } = new();

        public void OnGet(string? email)
        {
            // MOCK DATA: Giả lập lấy thông tin hiển thị từ query param hoặc tempdata
            // Trong thực tế sẽ không truy cập DB tại đây
            VerifyVM.TargetDestination = email ?? "your email/phone";
            VerifyVM.CanResend = false;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: Gọi Service/Mediator để verify OTP
            // var result = await _authService.VerifyOtpAsync(VerifyVM);

            // Success
            return RedirectToPage("/Index");
        }
    
    }
}
