using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayCourt.Application.ViewModels.VenueRegistration;

namespace PlayCourt.WebApp.Pages.Venue
{
    public class RegisterModel : PageModel
    {
        public VenueRegistrationViewModel Data { get; set; } = new();

        public void OnGet()
        {
            // MOCK DATA: Replace with actual service
            Data = new VenueRegistrationViewModel
            {
                AvailableSportTypes = new List<string>
                {
                    "Pickleball",
                    "Tennis",
                    "Badminton",
                    "Padel"
                },
                AvailableAmenities = new List<AmenityDto>
                {
                    new() { Id = "1", Name = "Floodlights" },
                    new() { Id = "2", Name = "Parking" },
                    new() { Id = "3", Name = "Water" },
                    new() { Id = "4", Name = "Showers" }
                },
                Progress = new RegistrationProgressDto
                {
                    CompletionPercentage = 35,
                    Steps = new List<ProgressStepDto>
                    {
                        new() { Name = "Account Created", Status = "done", Icon = "check_circle" },
                        new() { Name = "Venue Identity", Status = "active", Icon = "radio_button_checked" },
                        new() { Name = "Document Upload", Status = "pending", Icon = "radio_button_unchecked" },
                        new() { Name = "Expert Verification", Status = "pending", Icon = "radio_button_unchecked" }
                    }
                }
            };
        }
    }
}
