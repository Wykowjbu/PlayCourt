using Application.ViewModels.Matches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Matches
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateMatchRequestViewModel Input { get; set; } = new();

        public void OnGet()
        {
            // TODO: Load available sports and venues from Application Service
            // Example: Input = await _matchService.GetCreateMatchFormDataAsync();

            // Initialize dropdown data
            Input.AvailableSports = new List<string>
            {
                "Pickleball",
                "Tennis",
                "Badminton",
                "Padel"
            };

            Input.AvailableVenues = new List<string>
            {
                "My Khe Pickleball Arena",
                "Riverside Tennis Complex",
                "Dragon Bridge Arena",
                "Son Tra Sports Center"
            };

            // Set default values
            Input.SelectedSport = "Pickleball";
            Input.Venue = "My Khe Pickleball Arena";
            Input.DateTime = "Friday, Oct 27 • 18:30 - 20:30";
            Input.MinimumSkillLevel = 3;
            Input.PlayersNeeded = 3;
            Input.CostSharingMode = "Split Equally";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload dropdown data if validation fails
                OnGet();
                return Page();
            }

            // TODO: Call Application Service to create match request
            // Example:
            // var result = await _matchService.CreateMatchRequestAsync(
            //     Input.SelectedSport,
            //     Input.Venue,
            //     Input.DateTime,
            //     Input.MinimumSkillLevel,
            //     Input.PlayersNeeded,
            //     Input.CostSharingMode
            // );
            //
            // if (result.Succeeded)
            // {
            //     TempData["SuccessMessage"] = "Match request created successfully!";
            //     return RedirectToPage("/Matches/Index");
            // }
            // else
            // {
            //     ModelState.AddModelError("", result.ErrorMessage);
            //     OnGet();
            //     return Page();
            // }

            // Temporary redirect for demo
            TempData["SuccessMessage"] = "Match request created successfully!";
            return RedirectToPage("/Matches/Index");
        }
    }
}
