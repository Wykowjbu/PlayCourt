using Application.ViewModels.Players;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Profile
{
    public class SecurityModel : PageModel
    {
        [BindProperty]
        public SecurityViewModel Input { get; set; } = new();

        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            // TODO: Load current user data from Application Service
            // Example: var userData = await _userService.GetSecurityInfoAsync(userId);
            
            // Sample data for demonstration
            Input = new SecurityViewModel
            {
                RecoveryEmail = "johndoe.sports@playcourt.com",
                IsRecoveryEmailVerified = true,
                LastPasswordChangeDate = "6 months ago"
            };
        }

        public async Task<IActionResult> OnPostChangePasswordAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please correct the errors and try again.";
                return Page();
            }

            // TODO: Call Application Service to change password
            // Example: 
            // var result = await _identityService.ChangePasswordAsync(
            //     userId, 
            //     Input.CurrentPassword, 
            //     Input.NewPassword
            // );
            //
            // if (result.Succeeded)
            // {
            //     SuccessMessage = "Password updated successfully!";
            //     return RedirectToPage();
            // }
            // else
            // {
            //     ErrorMessage = result.ErrorMessage;
            //     return Page();
            // }

            // Temporary success message for demo
            SuccessMessage = "Password updated successfully!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostChangeRecoveryEmailAsync(string newEmail)
        {
            // TODO: Implement recovery email change logic
            // Call Application Service
            
            SuccessMessage = "Recovery email change request sent. Please check your inbox.";
            return RedirectToPage();
        }
    }
}
